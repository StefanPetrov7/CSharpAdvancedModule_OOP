using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalRefactured
{
    public class Departments
    {
        public Departments(string name)
        {
            Name = name;
            Rooms = new List<Room>();
            CreateRooms();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void AddPatientToRoom(Patient patient)
        {
            Room currentRoom = Rooms.FirstOrDefault(room => !room.IsFull);

            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                Rooms.Add(new Room());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
