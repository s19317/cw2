using System;
using System.IO;
using System.Xml.Serialization;
using cw2.Models;

namespace cw2         
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : @"Files/data.csv";
            var outputPath = args.Length > 1 ? args[1] : @"Files\result";
            var outputType = args.Length > 2 ? args[2] : "xml";


            try
            {


                if (!File.Exists(inputPath))
                    throw new FileNotFoundException("ERR", inputPath.Split("\\")[^1]);

                var university = new Uczelnia
                {
                    Author = "Jan Kowalski"
                };


                foreach (var line in File.ReadAllLines(inputPath))
                {
                    var splitted = line.Split(",");

                    if (splitted.Length != 9)
                    {
                        File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} wrong informations\n");
                        continue;
                    }

                    if (splitted[0] == "" || splitted[1] == "" || splitted[2] == "" || splitted[3] == "" || splitted[4] == "" ||
                        splitted[5] == "" || splitted[6] == "" || splitted[7] == "" || splitted[8] == "")
                    {
                        File.AppendAllText(@"Files\Log.txt", $"ERR Empty column in line { line}\n");
                        continue;
                    }

                    var student = new Student
                    {

                        Imie = splitted[0],
                        Nazwisko = splitted[1],
                        s = "s" + splitted[4],
                        date = splitted[5],
                        Mail = splitted[6],
                        MothersName = splitted[7],
                        FathersName = splitted[8],
                        Studies = new Studies()
                        {
                            name = splitted[2],
                            mode = splitted[3],
                        }

                    };

                    var nowStudy = new NowStudy
                    {
                        Name = splitted[2],
                        Students = 1
                    };

                    university.Students.Add(student);


                    if (university.getNow(nowStudy) != null)
                    {
                        university.getNow(nowStudy).Students++;
                    }
                    else
                    {
                        university.nowStudy.Add(nowStudy);
                    }

                }


                using var writer = new FileStream($"{outputPath}.{outputType}", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, university);

            }
            catch (FileNotFoundException e)
            {
                File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} {e.Message} File not found ({e.FileName})\n");
            }
        }
    }
}