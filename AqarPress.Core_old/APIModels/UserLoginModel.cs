using AqarPress.View.DtoClasses;
using System;

namespace AqarPress.Core.APIModels
{
    public class UserLoginModel
    {
        public string MobileNumber { get; set; }
        public string Password { get; set; }

        public string DeviceToken { get; set; }

        public class Reply
        {

            public Reply(UserView user)
            {
                Id = user.Id;
                Name = user.Name;
                MobileNumber = user.MobilePhone;
                LastLoginDate = user.LastLoginDate;
                RoleId = user.RoleId;
            }

            public string MobileNumber { get; set; }

            public string DeviceToken { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime? LastLoginDate { get; set; }

            public int RoleId { get; set; }

            public string SessionId { get; set; }
        }
    }
}