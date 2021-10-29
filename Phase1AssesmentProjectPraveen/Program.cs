using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1AssesmentProjectPraveen
{
    class TeacherDatabase
    {
        public static string fileName;
        static TeacherDatabase() => fileName = "C:\\bin\\Teacher_Records.txt";

        public void createTextFile()
        {
            ///Code to create File - First Time
            //string fileName = "C:\\bin\\Teacher_Records.txt";
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            fileStream.Close();
            using (StreamWriter streamWriter = File.CreateText(fileName))
            {
                streamWriter.Write("ID\t");
                streamWriter.Write("Name\t");
                streamWriter.Write("Class&Section\t");
            }
            Console.WriteLine("New File Created Successfully");

        }
        public void store(int teacherId, string teacherName, string teacherClassandSection)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(" ");
                    streamWriter.Write(teacherId+ "\t");
                    streamWriter.Write(teacherName + "\t");
                    streamWriter.Write(teacherClassandSection + "\t");
                    Console.WriteLine("Teacher Id : {0}", teacherId);
                    Console.WriteLine("Teacher Name : {0}", teacherName);
                    Console.WriteLine("Teacher Class&Section : {0}", teacherClassandSection);
                    Console.WriteLine("Teacher Data Stored Successfully");
                }
            }

        }

        public void retrive(string retriveVariable)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string s in lines)
            {
                //Console.WriteLine(s);
                if (s.Contains(retriveVariable))
                {
                    Console.WriteLine("Teacher Record Retrived is : " + s);
                    string[] teacherList = s.Split("\t");
                    Console.WriteLine("Teacher Id : {0}", teacherList[0]);
                    Console.WriteLine("Teacher Name : {0}", teacherList[1]);
                    Console.WriteLine("Teacher Class&Section : {0}", teacherList[2]);
                    Console.WriteLine("Teacher Data Retrived Successfully");

                }
            }

            
        }
        public void update(string oldValue, string newValue)
        {

            File.WriteAllText(fileName, File.ReadAllText(fileName).Replace(oldValue, newValue));
            Console.WriteLine("Teacher Data Updated Successfully");
            string[] lines = File.ReadAllLines(fileName);
            foreach (string s in lines)
            {
                //Console.WriteLine(s);
                if (s.Contains(newValue))
                {
                    Console.WriteLine("Teacher Record Updated is : " + s);
                    string[] teacherList = s.Split("\t");
                    Console.WriteLine("Teacher Id : {0}", teacherList[0]);
                    Console.WriteLine("Teacher Name : {0}", teacherList[1]);
                    Console.WriteLine("Teacher Class&Section : {0}", teacherList[2]);


                }
            }
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            TeacherDatabase teacherdatebase = new TeacherDatabase();
            teacherdatebase.createTextFile();
            Console.WriteLine("*****************************************************");
            //Code to Store Data
            teacherdatebase.store(1000, "Praveen", "9A");
            teacherdatebase.store(1001, "Raj", "10B");
            teacherdatebase.store(1002, "Bala", "11C");
            Console.WriteLine("******************************************************");
            //Code to Retrive Data
            teacherdatebase.retrive("Praveen");
            teacherdatebase.retrive("1001");
            teacherdatebase.retrive("11C");
            Console.WriteLine("******************************************************");
            //Code to Update Data
            teacherdatebase.update("Praveen", "Naveen");
            teacherdatebase.update("1002", "1003");
            teacherdatebase.update("11C", "12D");
            Console.WriteLine("******************************************************");
            Console.ReadKey();
        }
    }
}
