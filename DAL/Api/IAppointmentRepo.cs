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
        // its so big we dont need all of it, why you did it?
        //Task<List<Appointment>> GetAllAppointments();
        Task AddAppointment(Appointment appointment);
        Task DeleteAppointment(int id);
        Task<List<Appointment>> GetAppointmentsByPatientId(int patientId);

        //Task<Appointment> GetAppointmentById(int id);

        Task UpdateAppointment(Appointment appointment);
        

        // פונקציות נוספות לפי הצורך:
        Task<List<Appointment>> GetAppointmentsByPatientIdAndDate(int patientId, DateOnly date);
        Task<Appointment> GetAppointmentsByPatientAndThetapistIdIdAndDate(int patientId, DateOnly date, int therapistId);
        Task<List<Appointment>> GetAppointmentsByTherapistIdAndDate(int therapistId, DateOnly date);
        Task<List<Appointment>> GetAppointmentsByTherapistId(int therapistId);
        Task<bool> IsTimeSlotAvailable(DateOnly date, TimeOnly time, int therapistId);
    }
}
