using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test;

namespace UnitTestProject1
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void AddLine_ValidArgumentsForCommaDelimiter_LineAdded()
        {
            // arrange 
            string newLine = "Smiths,Chris,M,Red,02/09/1991";
            //act
            FileManager.AddLine(newLine);

            var actual = FileManager.FileContentList.Count; 
            Assert.AreEqual(1, actual, "New line  was not added correctly for comma delimited file");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Delimiter not found.")]
        public void AddLine_InvalidDelimiter_ExceptionThrown()
        {
            string newLine = "SmithsQChrisQMQRedQ02/09/1991";
            FileManager.AddLine(newLine);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Invalid date")]
        public void AddLine_InvalidBirthday_ExceptionThrown()
        {
            string newLine = "Smiths|Chris|M|Red|02/091991";
            FileManager.AddLine(newLine);
        }
    }
}
