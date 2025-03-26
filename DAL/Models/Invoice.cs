using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int PatientId { get; set; }

    public DateOnly InvoiceDate { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
