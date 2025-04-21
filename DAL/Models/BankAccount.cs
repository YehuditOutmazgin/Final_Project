using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class BankAccount
{
    public int AccountId { get; set; }

    public string BillingAccount { get; set; } = null!;

    public int TherapistId { get; set; }

    public string BankName { get; set; } = null!;

    public string BranchNumber { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string AccountHolderName { get; set; } = null!;

    public virtual ICollection<Therapist> Therapists { get; set; } = new List<Therapist>();
}
