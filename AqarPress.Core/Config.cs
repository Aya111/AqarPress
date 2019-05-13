using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPress.Core
{
   public class Config
    {
        public const int ALL_OPTION_VALUE = -1;
        public const int NONE_OPTION_VALUE = -2;

        public const string API_SESSION_OBJECT = "AqarPress-API-Session-object";
        public const string API_SESSION_HEADER = "AqarPress-UserSessionId";

        public static DateTime GetSystemTime() => DateTime.UtcNow;
    }
}
