using AqarPress.Core.Identity;
using AqarPress.Core.Repositories;
using DB_A4D6F8_AqarPress.Data.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using View.DtoClasses;
using View.Persistence;

namespace AqarPress.Core
{
    public class IdentityService : ICreateInScope
    {
        private IDistributedCache _cache;
        private UserRepository _userRepository;

        public IdentityService(UserRepository userRepository, IDistributedCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        private string GetUserSessionKey(Guid id) => $"Scops_{id.ToString().Replace("-", "_")}";

        public async Task<Result<APISession>> Login(string mobilePhone, string password, string deviceToken)
        {
            using (var adapter = Adapter.Create())
            {
                try
                {
                    var meta = new LinqMetaData(adapter);

                    var query = from u in meta.User
                                where u.MobilePhone == mobilePhone
                                select u;

                    Log.Information("Mobile {0}, password {1}", mobilePhone, password);

                    var result = await query.ProjectToUserView().SingleOrDefaultAsync();


                    Log.Information("login result is {0}", result);

                    bool userExist;

                    if (result == null)
                    {
                        userExist = false;
                    }

                    userExist = true;

                    if (userExist == true)
                    {
                        var verifiedPassword = Crypto.VerifyHashedPassword(result.Password, password);
                        if (verifiedPassword)
                        {
                            var session = await AddSession(result);
                            await _userRepository.ChangeLoginDataForMobileUsers(result, deviceToken);

                            return Result<APISession>.True(session);
                        }
                        else
                        {
                            Log.Debug("Password is not true");
                            return Result<APISession>.False("Invalid Password.");
                        }
                    }
                    else
                    {
                        Log.Information("User is not found.");
                        return Result<APISession>.False("User is not found.");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, string.Empty);
                    return Result<APISession>.False(ex.Message);
                }
            }
        }

        //public async Task<Result<None>> ChangePassword(int userId, string oldPassword, string newPassword)
        //{
        //    var userExist = await Query.GetAsync(async meta =>
        //    {
        //        var query = meta.User.Where(u => u.Id == userId && u.UserRoles
        //                            .Select(r => r.RoleId).Contains((int)Role.Participant));

        //        var user = await query.ProjectToUserView().SingleOrDefaultAsync();

        //        if (user == null)
        //        {
        //            Log.Debug("Email is incorect or user is not participant");
        //            return Result<UserView>.False();
        //        }

        //        return Result<UserView>.True(user);
        //    });

        //    if (userExist.IsTrue)
        //    {
        //        var result = await _userRepository.ChangePassword(userExist.Value, newPassword, oldPassword);
        //        if (result.IsFalse)
        //        {
        //            Log.Error(result.Message);
        //            return Result<None>.False(result.Message);
        //        }

        //        return Result<None>.True(None.Instance);
        //    }

        //    return Result<None>.False("User is not found.");
        //}

        public APISession GetSession(string sessionId)
        {
            sessionId = "Scops_" + sessionId;

            var item = _cache.Get<APISession>(sessionId);

            return item;
        }

        public async Task<APISession> AddSession(UserView user)
        {
            var session = new APISession(user);
            session.Id = Guid.NewGuid();
            session.SessionId = GetUserSessionKey(session.Id);

            await _cache.SetSession(session.SessionId, session, null);

            return session;
        }

        public Result<APISession> GetUserSessionInfo(HttpContext context)
        {
            var isSessionExisted = context.Items.TryGetValue(Config.API_SESSION_OBJECT, out object headerSession);

            if (isSessionExisted)
            {
                var session = headerSession as APISession;

                return Result<APISession>.True(session);
            }

            return Result<APISession>.False("Session Id should be sent");
        }
    }
}