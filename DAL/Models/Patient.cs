using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public int HmoId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Hmo Hmo { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
