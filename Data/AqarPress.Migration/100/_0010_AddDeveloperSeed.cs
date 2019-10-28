using System.Data;
using NPOI.HSSF.UserModel;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using FluentMigrator;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using AqarPress.Core.APIModels;
using System.Linq;
using Serilog;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace AqarPress.Migration._100
{
    [Migration(10)]
    public class _0010_AddDeveloperSeed : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            var log = new LoggerConfiguration()
                      .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                      .CreateLogger();

            this.Execute.WithConnection((conn, trans) =>
            {
                XSSFWorkbook xssfwb;
                var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var rootPath = Path.Combine(currentPath, "Aqar_Press_data15-4-2019");
                var filePath = Path.Combine(rootPath, "all_data aqar press15-4-2019.xlsx");
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    xssfwb = new XSSFWorkbook(file);
                }

                ISheet sheet = xssfwb.GetSheet("Sheet1");


                var currentDeveloperId = 0;
                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    Console.WriteLine(rowNum);

                    var row = sheet.GetRow(rowNum);

                    Console.WriteLine(row.GetCell(0).ToString());

                    if (row != null)
                    {
                        var developerName = row.GetCell(0).ToString().Trim();
                        var developerArabicName = row.GetCell(1).ToString().Trim();


                        if (!string.IsNullOrEmpty(developerName))
                        {
                            var dirInfo = new DirectoryInfo(rootPath);

                            Console.WriteLine("Developer name is " + developerName);
                            Console.WriteLine("from if");

                            var developerPath = developerName + ".jpg";

                            Console.WriteLine("after path");
                            var insertDeveloper = conn.CreateCommand();
                            insertDeveloper.Transaction = trans;
                            insertDeveloper.CommandText = $"INSERT INTO {Tables.Developer} (name, arabic_name, path) values ('{developerName}', '{developerArabicName}', '{developerPath}') select scope_identity();";

                            Console.WriteLine(insertDeveloper.CommandText);
                            var developerId = insertDeveloper.ExecuteScalar();
                            Console.WriteLine(developerId);
                            currentDeveloperId = int.Parse(developerId.ToString());

                            Console.WriteLine("inserted");
                        }

                        var projectName = row.GetCell(2).ToString().Trim();
                        var projectArabicName = row.GetCell(3).ToString().Trim();

                        Console.WriteLine("project name " + projectName);
                        var projectCategory = row.GetCell(4).ToString().Trim();

                        var getType = conn.CreateCommand();
                        getType.Transaction = trans;
                        getType.CommandText = $"SELECT id from {Tables.Category} where name like '%{projectCategory}%'";
                        var categoryId = getType.ExecuteScalar();
                        Console.WriteLine($"SELECT id from {Tables.Category} where name like '%{projectCategory}%'");

                        var projectPath = projectName + ".jpg";

                        var insertProject = conn.CreateCommand();
                        insertProject.Transaction = trans;
                        insertProject.CommandText = $@"INSERT INTO {Tables.Project} (name, arabic_name, category_id, developer_id, path)
                                                    values ('{projectName}','{projectArabicName}', '{categoryId}', '{currentDeveloperId}', '{projectPath}')";
                        Console.WriteLine(insertProject.CommandText);
                        var rowsAffected = insertProject.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected);
                    }

                }
            });
        }
    }
}
