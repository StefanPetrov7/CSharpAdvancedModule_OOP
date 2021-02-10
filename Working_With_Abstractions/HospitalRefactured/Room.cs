using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalRefactured
{
    public class Room
    {
        public Room()
        {
            Patients = new List<Patient>();
        }

        public bool IsFull => this.Patients.Count >= 3;

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
