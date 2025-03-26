using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    internal interface IPatientRepo
    {
        //Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        //Task DeletePatientAsync(int id);
        Task<List<Appointment>> GetPatientAppointmentsAsync(int patientId);
    }
}
