using System;
using System.Linq;

namespace HospitalRefactured
{
    public class Engine
    {
        private Hostital hospital;

        public Engine()
        {
            hospital = new Hostital();
        }

        public void Run()
        {
            string input;
            string END_ENTERING = "Output";

            while ((input = Console.ReadLine()) != END_ENTERING)
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string department = arg[0];
                string firstName = arg[1];
                string secondName = arg[2];
                string patientName = arg[3];
                string fullName = firstName + " " + secondName;

                hospital.AddDoctor(firstName, secondName);
                hospital.AddDepartment(department);
                hospital.AddPatient(department, fullName, patientName);

            }

            END_ENTERING = "End";

            while ((input = Console.ReadLine()) != END_ENTERING)
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arg.Length == 1)
                {
                    string department = arg[0];
                    Console.WriteLine(hospital.Departments.FirstOrDefault(dep => dep.Name == department));

                }
                else
                {
                    bool isRoom = int.TryParse(arg[1], out int resultRoom);

                    if (isRoom)
                    {
                        string departmentName = arg[0];
                        Departments department = hospital.Departments.FirstOrDefault(dep => dep.Name == departmentName);
                        Console.WriteLine(department.Rooms[resultRoom - 1].ToString());
                    }
                    else
                    {
                        string fullName = arg[0] + " " + arg[1];
                        Console.WriteLine(hospital.Doctors.FirstOrDefault(doc => doc.FullName == fullName).ToString());
                    }
                }
            }
        }
    }
}
