using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public static class FileManager
    {
        private static List<FileContentsModel> _fileContentList = new List<FileContentsModel>();

        public static IList<FileContentsModel> FileContentList
        {
            get
            {
                return _fileContentList;
            }
        }

        public static void AddLine(string line)
        {
            var delimiter = GetDelimiter(line);
            string[] values = line.Split(delimiter.ToCharArray());

            DateTime dateValue;
            if (!DateTime.TryParse(values[4], out dateValue))
                throw new Exception("Invalid date");
            
            FileContentsModel fileContents = new FileContentsModel
            {
                LastName = values[0],
                FirstName = values[1],
                Gender = values[2],
                FavoriteColor = values[3],
                DateOfBirth = dateValue
            };
            _fileContentList.Add(fileContents);
        }

        public static  void  ReadFileContents(string filePath )
        {
            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                AddLine(line);
            }
        }

        private static string GetDelimiter(string line)
        {
            if (line.IndexOf("|") > -1)
                return "|";
            else if (line.IndexOf(",") > -1)
                return ",";
            else if (line.IndexOf(" ") > -1)
                return " ";
            else
                throw new Exception("Delimiter not found.");
        }
    }
}
