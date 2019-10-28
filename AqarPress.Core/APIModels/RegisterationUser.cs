using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.DtoClasses;

namespace AqarPress.Core.APIModels
{
    public class RegisterationUser
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string MobileNumber { get; set; }

        public string DeviceToken { get; set; }

    }
}
