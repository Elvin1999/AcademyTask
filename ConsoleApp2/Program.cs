using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AcademyN1
{

    public class MySerializer
    {
        public static void Serialize(Academy academy)
        {
            var xml = new XmlSerializer(typeof(Academy));
            using (var fs = new FileStream("Academy.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, academy);
            }
        }
        public static Academy Deserialize()
        {
            Academy academy = null;
            var xml = new XmlSerializer(typeof(Academy));

            using (var fs = new FileStream("Academy.xml", FileMode.OpenOrCreate))
            {
                academy = xml.Deserialize(fs) as Academy;
            }
            return academy;
        }
    }
    [Serializable]
    public class Academy
    {
        public string Name { get; set; } = "IT Academy";
        public List<Subject> Subjects { get; set; }

        public void ShowSubject()
        {
            int no = 1;
            foreach (var academy in Subjects)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"        [{no++}] ");
                Console.ResetColor();
                academy.Show();
                Console.WriteLine();

            }
        }
    }
    [Serializable]
    public class Subject
    {

        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }

        public void Show()
        {
            Console.WriteLine($" {Name}");
        }

        public void AllTeacherShow()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"                 Subject:  {Name}");
            Console.ResetColor();
            Console.WriteLine();
            int no = 1;
            foreach (Teacher teacher in Teachers)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{no++}]");
                Console.ResetColor();
                teacher.TeacherShow();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }

        }

    }
    [Serializable]
    public class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public List<Group> Groups { get; set; }


        public void TeacherShow()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Experience: {Experience}");

        }

        public void AllGroup()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"                   Teacher: {Name}");
            Console.ResetColor();
            Console.WriteLine();
            int no = 1;
            foreach (Group group in Groups)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{no++}]");
                Console.ResetColor();
                group.GroupShow();
                Console.WriteLine();

            }

        }

    }
    [Serializable]
    public class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public void GroupShow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Group: {Name}");
            Console.ResetColor();

        }

        public void ShowAllStudents()
        {
            foreach (var student in Students)
            {
                student.StudentShow();
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }


    }



    public class Notification
    {

    }
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StudentCount { get; set; }

        public void StudentShow()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
        }

    }

    public class Menu
    {
        public static void ChoiceGroup()
        {
            Console.Write("Choice Group: ");
            int secim = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" [1]");
            Console.ResetColor();
            Console.WriteLine(" Registrening a student");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" [2]");
            Console.ResetColor();
            Console.WriteLine(" Show All Students ");
            Console.WriteLine();
        }

        public static Student CreateStudent()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("            Registrening a student");
            Console.ResetColor();
            Console.WriteLine();
            Student student = new Student();
            Console.Write("Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Surname: ");
            student.Surname = Console.ReadLine();
            Console.Write("E-mail: ");
            student.Email = Console.ReadLine();
            Console.Write("Phone: ");
            student.Phone = Console.ReadLine();

            return student;
        }
        public static void Run()
        {
            Teacher t1 = new Teacher
            {

                Name = "Ayten",
                Surname = "Elekberova",
                Experience = 3,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="K-102",
                        Students = new List<Student>
                        {
                            new Student{ Name="John", Email="@gmail.com", Phone="phone", Surname="surname"}
                        }

                    },
                    new Group
                    {
                        Name="K-105"
                        ,Students = new List<Student>
                        {
                            new Student{ Name="Eli", Email="@gmail.com", Phone="phone", Surname="surname"}
                        }
                    },
                }

            };

            Teacher t2 = new Teacher
            {

                Name = "Babek",
                Surname = "Eliyev",
                Experience = 5,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="P-801",Students = new List<Student>
                        {
                            new Student{ Name="Samir", Email="@gmail.com", Phone="phone", Surname="surname"}
                        }
                    },
                    new Group
                    {
                        Name="P-692",Students = new List<Student>
                        {
                            new Student{ Name="Leyla", Email="@gmail.com", Phone="phone", Surname="surname"}
                        }
                    },
                }

            };

            Teacher t3 = new Teacher
            {

                Name = "Jale",
                Surname = "Babali",
                Experience = 1,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="K-108",Students = new List<Student>
                        {
                            new Student{ Name="Arif", Email="@gmail.com", Phone="phone", Surname="surname"}
                        }
                    },

                }

            };

            Teacher t4 = new Teacher
            {

                Name = "Aydin",
                Surname = "Agayev",
                Experience = 8,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="K-403",
                    },
                    new Group
                    {
                        Name="K-321",
                    },
                    new Group
                    {
                        Name="K-201",
                    },
                }

            };

            Teacher t5 = new Teacher
            {

                Name = "Samir",
                Surname = "Bedelov",
                Experience = 9,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="P-103",
                    },
                    new Group
                    {
                        Name="P-625",
                    },
                    new Group
                    {
                        Name="P-721",
                    },
                }

            };

            Teacher t6 = new Teacher
            {

                Name = "Xalide",
                Surname = "Seferli",
                Experience = 3,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="DA-107",
                    },

                }

            };
            Teacher t7 = new Teacher
            {

                Name = "Nezrin",
                Surname = "Abbasova",
                Experience = 9,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="DA-155",
                    },
                    new Group
                    {
                        Name="DA-322",
                    },
                }

            };

            Teacher t8 = new Teacher
            {

                Name = "Gulnar",
                Surname = "Esedova",
                Experience = 4,
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name="P-091",
                    },

                }

            };

            Subject subject1 = new Subject
            {
                Name = "Kibertehlukesizlik",
                Teachers = new List<Teacher> { t1, t3, t4 }
            };
            Subject subject2 = new Subject
            {
                Name = "Programming",
                Teachers = new List<Teacher> { t2, t5, t8 }
            };
            Subject subject3 = new Subject
            {
                Name = "Data Analtika",
                Teachers = new List<Teacher> { t6, t7 }
            };



            Academy academy = new Academy
            {
                Subjects = new List<Subject> { subject1, subject2, subject3 }
            };
            MySerializer.Serialize(academy);
            Console.WriteLine("Completed Serialization");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"                         *** {academy.Name} ***");
                Console.ResetColor();
                Console.WriteLine();
                academy.ShowSubject();
                Console.WriteLine();
                Console.Write("Choose Subject: ");
                int choice = int.Parse(Console.ReadLine());
                Subject currentSubject = null;
                Console.Clear();
                currentSubject = academy.Subjects[choice - 1];

                currentSubject.AllTeacherShow();

                Console.Write("Choose Teacher: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                var currentTeacher = currentSubject.Teachers[choice - 1];
                currentTeacher.AllGroup();
                Console.Write("Choose Group: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                var currentGroup = currentTeacher.Groups[choice - 1];
                currentGroup.ShowAllStudents();
                Console.Write("For Register Please Select [1]: ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    var student = CreateStudent();
                    currentGroup.AddStudent(student);
                }
            }

            Console.WriteLine();




            // break;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Menu.Run();
        }
    }
}


