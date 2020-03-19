using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using cw2.Models;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : @"Files\dasdsne.csv";
            var outputPath = args.Length > 1 ? args[1] : "@Files\Result.xml";
            var outputType = args.Length > 2 ? args[2] : "xml";

            try {
                if (!File.Exists(inputPath))
                    throw new FileNotFoundException("ERR", inputPath.Split("\\")[^1]);
                var list = new List<Student>();
                foreach (var line in File.ReadAllLines(inputPath)) {
                    var splitted = line.Split(",");
                    if (splitted.Length < 9) {
                        File.AppendAllText("Log.txt", contents: $"{DataType.UtcNow} ERR Nieprawidlowa liczba wartosci {line}");

                    }
                //File.AppendAllLines(outputPath, line + "\n");
                var stud = new Student
                    {
                        Imie = "aa",
                        Nazwisko = "bb",
                        Email = "a@h.pl"
                    };
                    list.Add(stud);
                }
            } catch (FileNotFoundException e) {
                File.AppendAllText("Log.txt", $"{DataTime.UtcNow} {e.Message} {e.FileName}"})

            }

        }
    }
}
