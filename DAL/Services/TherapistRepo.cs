using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Services
{
    internal class TherapistRepo:ITherapistRepo
    {
        private readonly DB_Manager _DB_Manager;
        public async Task AddTherapist(Therapist therapist)
        {
           
            
                _DB_Manager.Therapists.Add(therapist);
                await _DB_Manager.SaveChangesAsync();
            
            
        }

        public async Task DeleteTherapist(int id)
        {
            // חיפוש המטפל לפי מזהה
            var therapist = await _DB_Manager.Therapists.FindAsync(id);

            if (therapist == null)
            {
                throw new KeyNotFoundException($"Therapist with ID {id} was not found.");
            }

            // הסרת המטפל מהמאגר
            _DB_Manager.Therapists.Remove(therapist);

            // שמירת השינויים במסד הנתונים
            await _DB_Manager.SaveChangesAsync();
        }
        public async Task<List<Therapist>> GetAllTherapists()
        {
            // שליפת כל המטפלים מהמאגר
            return await _DB_Manager.Therapists.ToListAsync();
        }

        public async Task<Therapist> GetTherapistById(int id)
        {
            // חיפוש המטפל לפי מזהה
            var therapist = await _DB_Manager.Therapists.FindAsync(id);

            if (therapist == null)
            {
                throw new KeyNotFoundException($"Therapist with ID {id} was not found.");
            }

            return therapist;
        }

        public async Task UpdateTherapist(Therapist therapist)
        {
            if (therapist == null)
            {
                throw new ArgumentNullException(nameof(therapist), "Therapist cannot be null.");
            }

            // בדיקה אם המטפל קיים במסד הנתונים
            var existingTherapist = await _DB_Manager.Therapists.FindAsync(therapist.TherapistId);
            if (existingTherapist == null)
            {
                throw new KeyNotFoundException($"Therapist with ID {therapist.TherapistId} was not found.");
            }

            // עדכון פרטי המטפל
            _DB_Manager.Entry(existingTherapist).CurrentValues.SetValues(therapist);

            // שמירת השינויים במסד הנתונים
            await _DB_Manager.SaveChangesAsync();
        }
    }
}
