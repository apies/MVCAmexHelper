using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmexHelperV2.Models
{
    public class Charge
    {
        public virtual int Id { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual string Cardholder { get; set; }

        public virtual string Purpose { get; set; }

        public virtual DateTime DateofPurchase { get; set; }

        public virtual bool Approved { get; set; }

        public virtual bool Billable { get; set; }

        public virtual bool ApprovedToPush { get; set; }

        public ExpenseReport Report { get; set; }

    }
}