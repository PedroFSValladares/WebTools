using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Models.Finances {
    public class CreditCard {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Limit { get; set; }
        public float TotalUsed { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDate { get; set; }
    }
}
