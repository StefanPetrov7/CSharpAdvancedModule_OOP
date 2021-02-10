using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalRefactured
{
    public class Doctor
    {
        public Doctor(string name, string second)
        {
            FirstName = name;
            SecondName = second;
            Patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FullName => FirstName + " " + SecondName;

        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in Patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
