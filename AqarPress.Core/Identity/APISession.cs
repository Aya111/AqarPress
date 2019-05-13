using AqarPress.View.DtoClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPress.Core.Identity
{
    [Serializable]
    public class APISession
    {
        public APISession()
        {

        }
        public APISession(UserView user)
        {
            User = user;
            UserId = user.Id;
        }

        public Guid Id { get; set; }

        public string SessionId { get; set; }

        public int UserId { get; set; }

        public UserView User { get; private set; }
    }
}
