using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IronXL;
using NUnit.Framework.Internal;
using OfficeOpenXml;
using TestLibrary.Entitiy;

namespace TestLibrary.Utilities
{
    public class Util
    {
        //This can be used to Implemet common libs across the framework -- Satish
        public static string RandomString()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public static List<Contact> parseContactInfo(String fileName)
        {

            //use EPPlus
            using (ExcelPackage package = new ExcelPackage(fileName))
            {
                FileInfo existingFile = new FileInfo(fileName);
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colCount = worksheet.Dimension.End.Column; //get Column Count
                int rowCount = worksheet.Dimension.End.Row; //get row count
                List<Contact> contacts = new List<Contact>();
                for (int row = 1; row <= rowCount; row++)
                {
                    Contact contact = new Contact();

                    //Print data, based on row and columns position
                    //Console.WriteLine(" Row:" + row + " column:" + col + " Value:" +worksheet.Cells[row, col].Value?.ToString().Trim());
                    contact.firstname = worksheet.Cells[row, 1].Value?.ToString().Trim();

                    contact.lastname = worksheet.Cells[row, 2].Value?.ToString().Trim();
                    contact.preferredName = worksheet.Cells[row, 3].Value?.ToString().Trim();
                    contact.mobile = worksheet.Cells[row, 4].Value?.ToString().Trim();
                    contact.email = worksheet.Cells[row, 5].Value?.ToString().Trim();
                    contact.nabID = worksheet.Cells[row, 6].Value?.ToString().Trim();
                    contacts.Add(contact);

                }

                return contacts;
            }

        }
    }
    
}
