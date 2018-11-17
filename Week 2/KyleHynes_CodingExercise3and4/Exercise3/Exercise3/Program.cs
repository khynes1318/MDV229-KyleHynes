using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Classes> classes; ;
            Dictionary<string, List<Classes>> studentInfo = new Dictionary<string, List<Classes>>();

            //create students
            studentInfo.Add("Billy", null);
            studentInfo.Add("Bob", null);
            studentInfo.Add("Thorton", null);
            studentInfo.Add("Carl", null);
            studentInfo.Add("Betsy", null);

            string className;
            double grade;

            //Add Classes/grades for billy
            classes = new List<Classes>();
            className = "History of Adidas";
            grade = 96.50;
            Classes classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "How to Nike";
            grade = 89.90;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Understanding Puma 101";
            grade = 92.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Hollister Workshop";
            grade = 85.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Anatomy of North Face Jacktes";
            grade = 98.60;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            studentInfo["Billy"] = classes;

            //Add Classes/grades for Bob
            classes = new List<Classes>();
            className = "History of Adidas";
            grade = 90.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "How to Nike";
            grade = 92.40;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Understanding Puma 101";
            grade = 82.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Hollister Workshop";
            grade = 87.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Anatomy of North Face Jacktes";
            grade = 95.4;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            studentInfo["Bob"] = classes;

            //Add Classes/grades for Thorton
            classes = new List<Classes>();
            className = "History of Adidas";
            grade = 81.50;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "How to Nike";
            grade = 99.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Understanding Puma 101";
            grade = 78.5;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Hollister Workshop";
            grade = 96.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Anatomy of North Face Jacktes";
            grade = 98.60;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            studentInfo["Thorton"] = classes;

            //Add Classes/grades for Carl
            classes = new List<Classes>();
            className = "History of Adidas";
            grade = 100;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "How to Nike";
            grade = 94.5;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Understanding Puma 101";
            grade = 92.00;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Hollister Workshop";
            grade = 98.5;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Anatomy of North Face Jacktes";
            grade = 97.4;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            studentInfo["Carl"] = classes;

            //Add Classes/grades for betsy
            classes = new List<Classes>();
            className = "History of Adidas";
            grade = 92.4;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "How to Nike";
            grade = 89.90;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Understanding Puma 101";
            grade = 97;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Hollister Workshop";
            grade = 88.7;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            className = "Anatomy of North Face Jacktes";
            grade = 93.5;
            classTemp = new Classes(className, grade);
            classes.Add(classTemp);

            studentInfo["Betsy"] = classes;

            

            bool programIsRunning = true;
            
            //loop to display and continuosly run the program till the user chooses to exiy

            while (programIsRunning)
            {

                Console.Clear();
                Console.WriteLine("Welcome to the Exercise 3 program\n================\n");

                //display menu
                Console.WriteLine(
                    "1) Review Students\n" +
                    "2) Review GPA\n" +
                    "3) Edit Student\n" +
                    "4) Exit\n");

                Console.Write("Selection: ");

                //catch user response
                string input = Console.ReadLine().ToLower();

                //switch response to validate entry and execute as user requests
                switch (input)
                {
                    case "1":
                    case "one":
                        {
                            //new menu page that loops displays current students for user to select
                            bool studentSelect = true;
                            while (studentSelect)
                            {
                                Console.Clear();
                                Console.WriteLine("List of current students\n============\n");
                                Console.WriteLine("Please select a student to view class information...\n");
                                int i = 1;
                                foreach (string name in studentInfo.Keys)
                                {
                                    Console.WriteLine($"{i}) {name}");
                                    i++;
                                }
                                Console.WriteLine($"{i}) Exit\n");

                                Console.Write("Selection: ");

                                string input2 = Console.ReadLine().ToLower();

                                switch (input2)
                                {
                                    case "1":
                                    case "one":
                                    case "billy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Billy\n============\n");
                                            
                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Billy"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                            }

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "2":
                                    case "two":
                                    case "bob":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Bob\n============\n");

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Bob"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                            }

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "3":
                                    case "three":
                                    case "thorton":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Thorton\n============\n");

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Thorton"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                            }

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "4":
                                    case "four":
                                    case "carl":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Carl\n============\n");

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Carl"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                            }

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "5":
                                    case "five":
                                    case "betsy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Betsy\n============\n");

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Betsy"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                            }

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "6":
                                    case "six":
                                    case "exit":
                                        {
                                            studentSelect = false;
                                        }
                                        break;
                                }


                            }

                        }
                        break;
                    case "2":
                    case "two":
                        {
                            bool studentSelect = true;
                            while (studentSelect)
                            {
                                Console.Clear();
                                Console.WriteLine("List of current students\n============\n");
                                Console.WriteLine("Please select a student to view student GPA...\n");
                                int i = 1;
                                foreach (string name in studentInfo.Keys)
                                {
                                    Console.WriteLine($"{i}) {name}");
                                    i++;
                                }
                                Console.WriteLine($"{i}) Exit\n");

                                Console.Write("Selection: ");

                                string input2 = Console.ReadLine().ToLower();

                                switch (input2)
                                {
                                    case "1":
                                    case "one":
                                    case "billy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Billy\n============\n");

                                            double gpa = 0;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Billy"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - GPA: {GetGPA(val.Grade)}");
                                                gpa += GetGPA(val.Grade);
                                            }

                                            Console.WriteLine($"\nCumulative GPA: {gpa / 5}");

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "2":
                                    case "two":
                                    case "bob":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Bob\n============\n");

                                            double gpa = 0;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Bob"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - GPA: {GetGPA(val.Grade)}");
                                                gpa += GetGPA(val.Grade);
                                            }

                                            Console.WriteLine($"\nCumulative GPA: {gpa / 5}");

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "3":
                                    case "three":
                                    case "thorton":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Thorton\n============\n");

                                            double gpa = 0;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Thorton"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - GPA: {GetGPA(val.Grade)}");
                                                gpa += GetGPA(val.Grade);
                                            }

                                            Console.WriteLine($"\nCumulative GPA: {gpa / 5}");

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "4":
                                    case "four":
                                    case "carl":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Carl\n============\n");

                                            double gpa = 0;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Carl"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - GPA: {GetGPA(val.Grade)}");
                                                gpa += GetGPA(val.Grade);
                                            }

                                            Console.WriteLine($"\nCumulative GPA: {gpa / 5}");

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "5":
                                    case "five":
                                    case "betsy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Info: Betsy\n============\n");

                                            double gpa = 0;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Betsy"])
                                            {
                                                Console.WriteLine($"{val.ClassName} - GPA: {GetGPA(val.Grade)}");
                                                gpa += GetGPA(val.Grade);
                                            }

                                            Console.WriteLine($"\nCumulative GPA: {gpa / 5}");

                                            Console.WriteLine("\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "6":
                                    case "six":
                                    case "exit":
                                        {
                                            studentSelect = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case "3":
                    case "three":
                        {
                            bool studentSelect = true;
                            while (studentSelect)
                            {
                                Console.Clear();
                                Console.WriteLine("List of current students\n============\n");
                                Console.WriteLine("Please select a student to edit...\n");
                                int i = 1;
                                foreach (string name in studentInfo.Keys)
                                {
                                    Console.WriteLine($"{i}) {name}");
                                    i++;
                                }
                                Console.WriteLine($"{i}) Exit\n");

                                Console.Write("Selection: ");

                                string input2 = Console.ReadLine().ToLower();

                                switch (input2)
                                {
                                    case "1":
                                    case "one":
                                    case "billy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select a class to edit for student: Billy\n============\n");

                                            int n = 1;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Billy"])
                                            {
                                                Console.WriteLine($"{n}) {val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                                n++;
                                            }
                                            Console.Write("\n");

                                            int index = Validation.GetInt(1, 5, "Selection: ");
                                            index--;
                                            
                                            double newGrade = Validation.GetDouble($"\nNew numerical grade for {studentInfo.ElementAt(0).Value[index].ClassName}: ");

                                            studentInfo.ElementAt(0).Value[index].Grade = newGrade;

                                            Console.WriteLine("\nGrade successfully changed...\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "2":
                                    case "two":
                                    case "bob":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select a class to edit for student: Bob\n============\n");

                                            int n = 1;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Bob"])
                                            {
                                                Console.WriteLine($"{n}) {val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                                n++;
                                            }
                                            Console.Write("\n");

                                            int index = Validation.GetInt(1, 5, "Selection: ");
                                            index--;

                                            double newGrade = Validation.GetDouble($"\nNew numerical grade for {studentInfo.ElementAt(1).Value[index].ClassName}: ");

                                            studentInfo.ElementAt(1).Value[index].Grade = newGrade;

                                            Console.WriteLine("\nGrade successfully changed...\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "3":
                                    case "three":
                                    case "thorton":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select a class to edit for student: Thorton\n============\n");

                                            int n = 1;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Thorton"])
                                            {
                                                Console.WriteLine($"{n}) {val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                                n++;
                                            }
                                            Console.Write("\n");

                                            int index = Validation.GetInt(1, 5, "Selection: ");
                                            index--;

                                            double newGrade = Validation.GetDouble($"\nNew numerical grade for {studentInfo.ElementAt(2).Value[index].ClassName}: ");

                                            studentInfo.ElementAt(2).Value[index].Grade = newGrade;

                                            Console.WriteLine("\nGrade successfully changed...\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "4":
                                    case "four":
                                    case "carl":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select a class to edit for student: Carl\n============\n");

                                            int n = 1;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Carl"])
                                            {
                                                Console.WriteLine($"{n}) {val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                                n++;
                                            }
                                            Console.Write("\n");

                                            int index = Validation.GetInt(1, 5, "Selection: ");
                                            index--;

                                            double newGrade = Validation.GetDouble($"\nNew numerical grade for {studentInfo.ElementAt(3).Value[index].ClassName}: ");

                                            studentInfo.ElementAt(3).Value[index].Grade = newGrade;

                                            Console.WriteLine("\nGrade successfully changed...\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "5":
                                    case "five":
                                    case "betsy":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select a class to edit for student: Betsy\n============\n");

                                            int n = 1;

                                            //Loop that displays all of selected students classes and grades
                                            foreach (Classes val in studentInfo["Betsy"])
                                            {
                                                Console.WriteLine($"{n}) {val.ClassName} - {val.Grade} - {GradeLetter(val.Grade)}");
                                                n++;
                                            }
                                            Console.Write("\n");

                                            int index = Validation.GetInt(1, 5, "Selection: ");
                                            index--;

                                            double newGrade = Validation.GetDouble($"\nNew numerical grade for {studentInfo.ElementAt(4).Value[index].ClassName}: ");

                                            studentInfo.ElementAt(4).Value[index].Grade = newGrade;

                                            Console.WriteLine("\nGrade successfully changed...\nPress any key to continue...\n");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "6":
                                    case "six":
                                    case "exit":
                                        {
                                            studentSelect = false;
                                        }
                                        break;
                                }
                            }
                            }
                        break;
                    case "4":
                    case "four":
                        {
                            Console.Clear();
                            Console.WriteLine("User has chosen to exit the program\n\nHave a great day!\n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            programIsRunning = false;

                        }
                        break;
                }
            }
        }

        public static string GradeLetter(double grade)
        {
            string letterGrade;
            if (grade >= 89.5)
            {
                letterGrade = "A";
            }
            else if (grade >= 79.5 && grade <= 89.4)
            {
                letterGrade = "B";
            }
            else if (grade >= 72.5 && grade <= 79.4)
            {
                letterGrade = "C";
            }
            else if (grade >= 69.5 && grade <= 72.4)
            {
                letterGrade = "D";
            }
            else 
            {
                letterGrade = "F";
            }

            return letterGrade;
        }

        public static double GetGPA(double grade)
        {
            double gpa;
            if (grade >= 89.5)
            {
                gpa = 4.0;
            }
            else if (grade >= 79.5 && grade <= 89.4)
            {
                gpa = 3.0;
            }
            else if (grade >= 72.5 && grade <= 79.4)
            {
                gpa = 2.0;
            }
            else if (grade >= 69.5 && grade <= 72.4)
            {
                gpa = 1.0;
            }
            else
            {
                gpa = 0;
            }

            return gpa;
        }

    }
}
