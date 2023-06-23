using OfficeOpenXml;
using System;

namespace WorkingWithExcelSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
    }
}
