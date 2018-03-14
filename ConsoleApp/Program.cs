using RazorEngine;
using RazorEngine.Templating;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var template = "Hello @Model.Name, welcome to use RazorEngine!";
            var result = Engine.Razor.RunCompile(template, "templateKey1", null, new { Name = "World" });
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
