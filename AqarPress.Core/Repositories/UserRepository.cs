using DB_A4D6F8_AqarPress.Data.EntityClasses;
using DB_A4D6F8_AqarPress.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using View.DtoClasses;

namespace AqarPress.Core.Repositories
{
    public class UserRepository : ICreateInScope
    {

        public async Task<Result<UserView>> Create(UserView user)
        {
            try
            {
                using (var adapter = Adapter.Create())
                {
                    var userEntity = new UserEntity
                    {
                        Name = user.Name,
                        MobilePhone = user.MobilePhone,
                        Password = Crypto.HashPassword(user.Password),
                        RoleId = user.RoleId,
                        DeviceToken = user.DeviceToken
                    };

                    var result = await adapter.SaveEntityAsync(userEntity, true);

                    user.Id = userEntity.Id;

                    var meta = new LinqMetaData(adapter);

                    return Result<UserView>.True(user);
                }
            }
            catch (Exception ex)
            {
                return Result<UserView>.False(ex);
            }
        }
        public async Task<Result<bool>> ChangeLoginDataForMobileUsers(UserView user, string newDeviceToken)
        {
            using (var adapter = Adapter.Create())
            {
                try
                {
                    var userEntity = new UserEntity
                    {
                        IsNew = false,

                        Id = user.Id,
                        LastLoginDate = Config.GetSystemTime(),
                        DeviceToken = newDeviceToken
                    };

                    var dbResult = await adapter.SaveEntityAsync(userEntity);
                    return Result<bool>.True(dbResult);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, string.Empty);
                    return Result<bool>.False(ex);
                }
            };
        }

        public async Task<Result<bool>> IsTheMobileNumberExisted(string mobileNumber)
        {
            using (var adapter = Adapter.Create())
            {
                try
                {

                    var meta = new LinqMetaData(adapter);

                    var existed = await meta.User.AnyAsync(u => u.MobilePhone == mobileNumber);

                    return Result<bool>.True(existed);
                }
                catch(Exception ex)
                {
                    Log.Error(ex, string.Empty);
                    return Result<bool>.False();
                }
            }
        }
    }
}