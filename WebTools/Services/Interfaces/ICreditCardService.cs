using WebTools.Models.Finances;

namespace WebTools.Services.Interfaces
{
    public interface ICreditCardService
    {
        public IEnumerable<CreditCard> GetAllCreditCards();
        public void Create(CreditCard creditCard);
        public void Update(CreditCard creditCard);
        public void Delete(Guid Id);
        public IEnumerable<Expense> GetInvoice(int month, int year);
    }
}
