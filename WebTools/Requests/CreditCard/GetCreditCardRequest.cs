namespace WebTools.Requests.CreditCard {
    public class GetCreditCardRequest {
        public List<Models.Finances.CreditCard> creditCards { get; set; }
        public float TotalLimit { get; set; }
        public float TotalUsed { get; set; }
    }
}
