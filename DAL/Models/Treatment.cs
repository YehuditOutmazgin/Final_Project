using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public string TreatmentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }
}
