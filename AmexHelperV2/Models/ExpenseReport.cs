using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmexHelperV2.Models
{
    public class ExpenseReport
    {
        public virtual int Id { get; set; }
        public virtual string Month { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual List<Charge> Charges { get; set; }
        public virtual string Employee { get; set; }
    }
}