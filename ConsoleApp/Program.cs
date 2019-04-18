using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;
using Rocket.CodeBuilder;
using Rocket.CodeBuilder.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var template = "Hello @Model.Name, welcome to use RazorEngine!";
            //var result = Engine.Razor.RunCompile(template, "templateKey1", null, new { Name = "World" });
            //Console.WriteLine(result);

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("varchar", "String");
            //dic.Add("bit", "Bool");

            //string json = JsonConvert.SerializeObject(dic);
            //Console.WriteLine(json);

            DBDataType dBDataType = new DBDataType();
            dBDataType.Language = LanguageType.CSharp;
            dBDataType.DBType = new Dictionary<string, string>();
            dBDataType.DBType.Add("varchar", "String");
            dBDataType.DBType.Add("bit", "Bool");

            string json = JsonConvert.SerializeObject(new List<DBDataType> { dBDataType });
            Console.WriteLine(json);

            Console.Read();
        }
    }
}
