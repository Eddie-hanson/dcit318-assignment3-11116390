using System;
using System.IO;
using System.Collections.Generic;
using SchoolGradingSystem.Models;
using SchoolGradingSystem.Services;
using SchoolGradingSystem.Exceptions;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"C:\Users\Mr Hanson\Desktop\dcit318-assignment3-11116390\SchoolGradingSystem\students.txt" ; 
            string outputFilePath = @"C:\Users\Mr Hanson\Desktop\dcit318-assignment3-11116390\SchoolGradingSystem\report.txt";  

            var processor = new StudentResultProcessor();

            try
            {
                // Read students from file
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);

                // Write report to file
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
