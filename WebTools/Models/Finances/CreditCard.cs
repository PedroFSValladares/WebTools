using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebTools.Models.Finances {
    public class CreditCard {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Limit { get; set; }
        public float TotalUsed { get; set; }
        public int DueDate { get; set; }
        public int PaymentDay { get; set; }
        public CreditCardColor Color {get; set;}
    }

    public struct CreditCardColor {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public float Alpha { get; set; }
    }
}
