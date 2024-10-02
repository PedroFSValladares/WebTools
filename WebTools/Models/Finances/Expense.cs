using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Models.Finances {
    public class Expense {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public DateTime DateTime { get; set; }
        public bool Recurring { get; set; }
        public bool installment { get; set; }
    }
}
