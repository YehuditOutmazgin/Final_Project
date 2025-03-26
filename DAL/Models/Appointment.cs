﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int TherapistId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Therapist Therapist { get; set; } = null!;
}
