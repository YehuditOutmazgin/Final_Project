using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Hmo
{
    public int HmoId { get; set; }

    public string Name { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    //I made a change at this file
}
