using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using Newtonsoft.Json;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            var commaFilePath = @"C:\docs\commadelimited.txt";
            var pipeFilePath = @"C:\docs\pipedelimited.txt";
            var spaceFilePath = @"C:\docs\spacedelimited.txt";

            FileManager.ReadFileContents(",", commaFilePath);
            FileManager.ReadFileContents("|", pipeFilePath);
            FileManager.ReadFileContents(" ", spaceFilePath);

            //Output 1 – sorted by gender(females before males) then by last name ascending.
            var fileContentsSortedByGenderLastName =  JsonConvert.SerializeObject(FileManager.FileContentList.OrderBy(x=> x.Gender).OrderBy(x=>x.LastName), Formatting.Indented);
            Console.Write("Option 1" + fileContentsSortedByGenderLastName);

            //Output 2 – sorted by birth date, ascending.
            var fileContentsSortedByBirthdate = JsonConvert.SerializeObject(FileManager.FileContentList.OrderBy(x => x.DateOfBirth), Formatting.Indented);
            Console.Write("Option 2" + fileContentsSortedByBirthdate);

            //Output 3 – sorted by last name, descending.
            var fileContentsSortedByLastName = JsonConvert.SerializeObject(FileManager.FileContentList.OrderByDescending(x => x.LastName), Formatting.Indented);
            Console.Write("Option 3" + fileContentsSortedByLastName);


            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

    }
}
