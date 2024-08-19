using System.Drawing;

namespace WebTools.Requests.CreditCard
{
    public class CreateCreditCardRequest
    {
        public string Name { get; set; }
        public float Limit { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDay { get; set; }
        public Color Color {get; set;}
    }
}