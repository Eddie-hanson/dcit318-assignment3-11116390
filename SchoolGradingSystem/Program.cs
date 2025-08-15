using System;
using System.IO;
using SchoolGradingSystem.Models;
using SchoolGradingSystem.Services;
using SchoolGradingSystem.Exceptions;
using System.Collections.Generic;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "/students.txt";
            string outputFilePath = "report.txt";

            var processor = new StudentResultProcessor();

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                processor.WriteReportToFile(students, outputFilePath);
                Console.WriteLine("Report generated successfully!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: Input file not found. {ex.Message}");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Error: Invalid score format. {ex.Message}");
            }
            catch (StudentMissingFieldException ex)
            {
                Console.WriteLine($"Error: Missing field. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
