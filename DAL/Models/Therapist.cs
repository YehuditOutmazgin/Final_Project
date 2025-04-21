using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Therapist
{
    public int TherapistId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Specialization { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int BankAccountId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual BankAccount BankAccount { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
