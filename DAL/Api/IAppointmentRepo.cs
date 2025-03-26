using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    internal interface IAppointmentRepo
    {
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentsByPatientId(int patientId);

        //Task<Appointment> GetAppointmentById(int id);
        Task AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int id);

        // פונקציות נוספות לפי הצורך:
        Task<List<Appointment>> GetAppointmentsByPatientIdAndDate(int patientId, DateTime date);
        Task<Appointment> GetAppointmentsByPatientIdAndDate(int patientId, DateTime date, string therapis);

        Task<List<Appointment>> GetAppointmentsByTherapist(string therapist);
        Task<List<Appointment>> GetAppointmentsByTherapistAndDate(string therapist_name, DateTime date);
        Task<List<Appointment>> GetAppointmentsByTherapistId(string therapist_name);
        Task<bool> IsTimeSlotAvailable(DateTime date, TimeSpan time, int employeeId);
    }
}
