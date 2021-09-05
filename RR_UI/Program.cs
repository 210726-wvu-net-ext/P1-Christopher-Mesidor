using RR_UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using RR_DL.Entities;
using System.Diagnostics;

namespace RR_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string ConnectionString = File.ReadAllText(@"C:\Users\cm121\cmdbp0-connect.txt");

            var options = new DbContextOptionsBuilder<CMDBP0Context>()
                .LogTo(message => Debug.WriteLine(message))
                .UseSqlServer(ConnectionString)
                .Options;
            
            using var context = new CMDBP0Context(options);

            IMenu menu = new Menu(context);
            menu.Start();
        }
    }
}
