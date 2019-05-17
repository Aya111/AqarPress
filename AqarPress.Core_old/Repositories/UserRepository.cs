using AqarPress.Data.DatabaseSpecific;
using AqarPress.Data.EntityClasses;
using AqarPress.View.DtoClasses;
using Serilog;
using System;
using System.Threading.Tasks;

namespace AqarPress.Core.Repositories
{
    public class UserRepository : ICreateInScope
    {
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
                        //LastLoginDate = Config.GetSystemTime(),
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
    }
}