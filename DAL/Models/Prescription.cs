using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int TherapistId { get; set; }

    public DateOnly PrescriptionDate { get; set; }

    public string Medication { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Instructions { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Therapist Therapist { get; set; } = null!;
}
