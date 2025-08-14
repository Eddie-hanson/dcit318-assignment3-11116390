using System;
using System.Collections.Generic;
using System.Linq;
using HealthcareSystem.Models;
using HealthcareSystem.Repositories;

namespace healthcare_management_system.App
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            // Add Patients
            _patientRepo.Add(new Patient(1, "Alice", 30, "Female"));
            _patientRepo.Add(new Patient(2, "Bob", 45, "Male"));
            _patientRepo.Add(new Patient(3, "Charlie", 50, "Male"));

            // Add Prescriptions
            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Paracetamol", DateTime.Now.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Metformin", DateTime.Now.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(105, 2, "Vitamin C", DateTime.Now.AddDays(-1)));
        }

        public void BuildPrescriptionMap()
        {
            foreach (var prescription in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("All Patients:");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var prescription in _prescriptionMap[patientId])
                {
                    Console.WriteLine(prescription);
                }
            }
            else
            {
                Console.WriteLine($"\nNo prescriptions found for Patient ID {patientId}");
            }
        }
    }
}
