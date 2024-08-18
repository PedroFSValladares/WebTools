using WebTools.Models.Finances;

namespace WebTools.Models.Finance {
    public class Invoice {
        public int Id { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly PaymentDate { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
