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
            FileContentsModel fileContents = new FileContentsModel
            {
                LastName = values[0],
                FirstName = values[1],
                Gender = values[2],
                FavoriteColor = values[3],
                DateOfBirth = Convert.ToDateTime(values[4])
            };
            fileContentList.Add(fileContents);
        }

        public static  void  ReadFileContents(string delimiter, string filePath )
        {
            List<string> allLinesText = File.ReadAllLines(filePath).ToList();

            var list = allLinesText.Select(a => a.Split(delimiter.ToCharArray())).Select(a=> new FileContentsModel {
                LastName = a[0],
                FirstName = a[1],
                Gender = a[2],
                FavoriteColor = a[3],
                DateOfBirth = Convert.ToDateTime(a[4])
            }).ToList();

            fileContentList.AddRange(list);
        }

        private static string GetDelimiter(string line)
        {
            if (line.IndexOf("|") > -1)
                return "|";
            else if (line.IndexOf(",") > -1)
                return ",";
            else
                return " ";
        }
    }
}
