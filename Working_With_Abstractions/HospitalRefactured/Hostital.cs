using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalRefactured
{
    public class Hostital
    {
        public Hostital()
        {
            Doctors = new List<Doctor>();
            Departments = new List<Departments>();
        }

        public List<Doctor> Doctors { get; set; }

        public List<Departments> Departments { get; set; }

        public void AddDoctor(string first, string second)
        {
            if (!Doctors.Any(d => d.FullName == first + " " + second))
            {
                Doctor doctor = new Doctor(first, second);
                Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string name)
        {
            if (!Departments.Any(dep => dep.Name == name))
            {
                Departments department = new Departments(name);
                Departments.Add(department);
            }
        }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            Patient patient = new Patient(patientName);
            Departments department = Departments.FirstOrDefault(dep => dep.Name == departmentName);
            Doctor doctor = Doctors.FirstOrDefault(doc => doc.FullName == doctorName);

            department.AddPatientToRoom(patient);
            doctor.Patients.Add(patient);
        }
    }
}
