using System;
using System.Collections.Generic;
using System.IO;
using SchoolGradingSystem.Models;
using SchoolGradingSystem.Exceptions;

namespace SchoolGradingSystem.Services
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (var reader = new StreamReader(inputFilePath))
            {
                string line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    var parts = line.Split(',');

                    // Validate number of fields
                    if (parts.Length != 3)
                        throw new StudentMissingFieldException($"Line {lineNumber}: Missing required field(s).");

                    // Parse student ID
                    if (!int.TryParse(parts[0].Trim(), out int id))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format.");

                    // Parse full name
                    string fullName = parts[1].Trim();
                    if (string.IsNullOrEmpty(fullName))
                        throw new StudentMissingFieldException($"Line {lineNumber}: FullName is missing.");

                    // Parse score
                    if (!int.TryParse(parts[2].Trim(), out int score))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format.");

                    students.Add(new Student(id, fullName, score));
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    string reportLine = $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}";
                    writer.WriteLine(reportLine);
                }
            }
        }
    }
}
