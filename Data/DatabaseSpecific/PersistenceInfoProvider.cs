﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace DB_A4D6F8_AqarPress.Data.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	internal static class PersistenceInfoProviderSingleton
	{
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton() {	}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance() { return _providerInstance; }
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass();
			InitAdEntityMappings();
			InitAreaEntityMappings();
			InitAttachmentEntityMappings();
			InitCategoryEntityMappings();
			InitDeveloperEntityMappings();
			InitProjectEntityMappings();
			InitProjectDiscussionEntityMappings();
			InitProjectSubCategoryTableEntityMappings();
			InitRoleEntityMappings();
			InitSubCategoryEntityMappings();
			InitUserEntityMappings();
		}

		/// <summary>Inits AdEntity's mappings</summary>
		private void InitAdEntityMappings()
		{
			this.AddElementMapping("AdEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Ad", 5, 0);
			this.AddElementFieldMapping("AdEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AdEntity", "IsActive", "is_active", true, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 1);
			this.AddElementFieldMapping("AdEntity", "Name", "NAME", true, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("AdEntity", "Path", "path", true, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("AdEntity", "RedirectUrl", "redirect_url", true, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 4);
		}

		/// <summary>Inits AreaEntity's mappings</summary>
		private void InitAreaEntityMappings()
		{
			this.AddElementMapping("AreaEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Area", 3, 0);
			this.AddElementFieldMapping("AreaEntity", "ArabicName", "arabic_name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("AreaEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("AreaEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 2);
		}

		/// <summary>Inits AttachmentEntity's mappings</summary>
		private void InitAttachmentEntityMappings()
		{
			this.AddElementMapping("AttachmentEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Attachments", 4, 0);
			this.AddElementFieldMapping("AttachmentEntity", "Comment", "comment", true, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("AttachmentEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("AttachmentEntity", "Path", "path", false, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("AttachmentEntity", "ProjectDiscussionId", "project_discussion_id", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
		}

		/// <summary>Inits CategoryEntity's mappings</summary>
		private void InitCategoryEntityMappings()
		{
			this.AddElementMapping("CategoryEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Category", 3, 0);
			this.AddElementFieldMapping("CategoryEntity", "ArabicName", "arabic_name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("CategoryEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("CategoryEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 2);
		}

		/// <summary>Inits DeveloperEntity's mappings</summary>
		private void InitDeveloperEntityMappings()
		{
			this.AddElementMapping("DeveloperEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Developer", 5, 0);
			this.AddElementFieldMapping("DeveloperEntity", "ArabicName", "arabic_name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("DeveloperEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("DeveloperEntity", "IsActive", "is_active", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 2);
			this.AddElementFieldMapping("DeveloperEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("DeveloperEntity", "Path", "path", false, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 4);
		}

		/// <summary>Inits ProjectEntity's mappings</summary>
		private void InitProjectEntityMappings()
		{
			this.AddElementMapping("ProjectEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Project", 8, 0);
			this.AddElementFieldMapping("ProjectEntity", "ArabicName", "arabic_name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("ProjectEntity", "CategoryId", "category_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ProjectEntity", "DateCreated", "date_created", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2);
			this.AddElementFieldMapping("ProjectEntity", "DeveloperId", "developer_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
			this.AddElementFieldMapping("ProjectEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 4);
			this.AddElementFieldMapping("ProjectEntity", "IsActive", "is_active", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 5);
			this.AddElementFieldMapping("ProjectEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("ProjectEntity", "Path", "path", false, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 7);
		}

		/// <summary>Inits ProjectDiscussionEntity's mappings</summary>
		private void InitProjectDiscussionEntityMappings()
		{
			this.AddElementMapping("ProjectDiscussionEntity", @"DB_A4D6F8_AqarPress", @"dbo", "ProjectDiscussion", 5, 0);
			this.AddElementFieldMapping("ProjectDiscussionEntity", "CommenterId", "commenter_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ProjectDiscussionEntity", "DateCreated", "date_created", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1);
			this.AddElementFieldMapping("ProjectDiscussionEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("ProjectDiscussionEntity", "MessageBody", "message_body", true, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("ProjectDiscussionEntity", "ProjectId", "project_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 4);
		}

		/// <summary>Inits ProjectSubCategoryTableEntity's mappings</summary>
		private void InitProjectSubCategoryTableEntityMappings()
		{
			this.AddElementMapping("ProjectSubCategoryTableEntity", @"DB_A4D6F8_AqarPress", @"dbo", "ProjectSubCategoryTable", 3, 0);
			this.AddElementFieldMapping("ProjectSubCategoryTableEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ProjectSubCategoryTableEntity", "ProjectId", "project_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("ProjectSubCategoryTableEntity", "SubCategoryId", "sub_category_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits RoleEntity's mappings</summary>
		private void InitRoleEntityMappings()
		{
			this.AddElementMapping("RoleEntity", @"DB_A4D6F8_AqarPress", @"dbo", "Role", 2, 0);
			this.AddElementFieldMapping("RoleEntity", "Id", "id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("RoleEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits SubCategoryEntity's mappings</summary>
		private void InitSubCategoryEntityMappings()
		{
			this.AddElementMapping("SubCategoryEntity", @"DB_A4D6F8_AqarPress", @"dbo", "SubCategory", 3, 0);
			this.AddElementFieldMapping("SubCategoryEntity", "ArabicName", "arabic_name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("SubCategoryEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("SubCategoryEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 2);
		}

		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			this.AddElementMapping("UserEntity", @"DB_A4D6F8_AqarPress", @"dbo", "User", 8, 0);
			this.AddElementFieldMapping("UserEntity", "DateCreated", "date_created", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 0);
			this.AddElementFieldMapping("UserEntity", "DeviceToken", "device_token", true, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("UserEntity", "Id", "id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("UserEntity", "LastLoginDate", "last_login_date", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3);
			this.AddElementFieldMapping("UserEntity", "MobilePhone", "mobile_phone", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 4);
			this.AddElementFieldMapping("UserEntity", "Name", "name", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 5);
			this.AddElementFieldMapping("UserEntity", "Password", "password", false, "NVarChar", 500, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("UserEntity", "RoleId", "role_id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 7);
		}

	}
}
