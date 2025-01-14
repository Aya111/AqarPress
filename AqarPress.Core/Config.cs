﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AqarPress.Core
{
    public class Config
    {
        public const int ALL_OPTION_VALUE = -1;
        public const int NONE_OPTION_VALUE = -2;

        public const string API_SESSION_OBJECT = "AqarPress-API-Session-object";
        public const string API_SESSION_HEADER = "AqarPress-UserSessionId";

        public const string UPLOADS_PATH = "\\Uploads";

        public const string DEVELOPER_UPLOADS_PATH = UPLOADS_PATH + "\\Developer\\";

        public const string PROJECT_UPLOADS_PATH = UPLOADS_PATH + "\\Project\\";

        public const string AD_IMAGE_PATH = UPLOADS_PATH + "\\Ad\\";

        public const string DISCUSSION_ATTACHMENT_IMAGE_PATH = UPLOADS_PATH + "\\DiscussionAttachment\\";

        public static string GenerateDeveloperLogoPath(IHostingEnvironment env, string fileName)
        {
            return string.Concat(env.WebRootPath, DEVELOPER_UPLOADS_PATH, fileName);
        }

        public static string GenerateProjectLogoPath(IHostingEnvironment env, string fileName)
        {
            return string.Concat(env.WebRootPath, PROJECT_UPLOADS_PATH, fileName);
        }

        public static string GenerateAdImagePath(IHostingEnvironment env, string fileName)
        {
            return string.Concat(env.WebRootPath, AD_IMAGE_PATH, fileName);
        }

        public static string GenerateDiscussionAttachmentImagePath(IHostingEnvironment env, string fileName, int discussionId)
        {
            return string.Concat(env.WebRootPath, DISCUSSION_ATTACHMENT_IMAGE_PATH, discussionId, "\\", fileName);
        }

        public static DateTime GetSystemTime() => DateTime.UtcNow;
    }
}
