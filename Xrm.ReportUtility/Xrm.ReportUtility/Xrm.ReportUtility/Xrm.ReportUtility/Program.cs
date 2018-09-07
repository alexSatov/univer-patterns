using System;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            // Статический фабричный метод (переделал на switch)
            var fileExtension = args[0].Split('.')[1];

            switch (fileExtension)
            {
                case "txt":
                    return new TxtReportService(args);
                case "csv":
                    return new CsvReportService(args);
                case "xlsx":
                    return new XlsxReportService(args);
                default:
                    throw new NotSupportedException("this extension not supported");
            }
        }

        private static void PrintReport(Report report) // В отдельный класс + декомпозиция
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                var headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество"; // Антипаттерн hardcode, построение заголовка нужно вынести в отдельный метод, в зависимости от кол-ва параметров
                var rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";

                if (report.Config.WithIndex) // Копипаст + лапша из if-ов, нужно использовать цепочку обязанностей для простроения таблички
                {
                    headerRow = "№\t" + headerRow;
                    rowTemplate = "{0}\t" + rowTemplate;
                }
                if (report.Config.WithTotalVolume)
                {
                    headerRow = headerRow + "\tСуммарный объём";
                    rowTemplate = rowTemplate + "\t{6,15}";
                }
                if (report.Config.WithTotalWeight)
                {
                    headerRow = headerRow + "\tСуммарный вес";
                    rowTemplate = rowTemplate + "\t{7,13}";
                }

                Console.WriteLine(headerRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost,
                        dataRow.Count, dataRow.Volume*dataRow.Count, dataRow.Weight*dataRow.Count);
                }

                Console.WriteLine();
            }

            if (report.Rows == null || !report.Rows.Any()) return;
            Console.WriteLine("Итого:");
            foreach (var reportRow in report.Rows)
            {
                Console.WriteLine($"  {reportRow.Name,-20}\t{reportRow.Value}");
            }
        }
    }
}