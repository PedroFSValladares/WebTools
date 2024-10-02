using WebTools.Requests.CreditCard;

namespace WebTools.Utilities
{
    public static class Extractor
    {
        public static Models.Finances.CreditCard GetCreditCardFromRequest(BaseCreditCardRequest creditCardRequest)
        {
            return new Models.Finances.CreditCard {
                Id = Guid.NewGuid(),
                Name = creditCardRequest.Name,
                Limit = creditCardRequest.Limit,
                TotalUsed = 0,
                DueDate = creditCardRequest.DueDate.Day,
                PaymentDay = creditCardRequest.PaymentDay.Day,
                Color = new Models.Finances.CreditCardColor {
                    Blue = creditCardRequest.Color.B,
                    Red = creditCardRequest.Color.R,
                    Green = creditCardRequest.Color.G,
                    Alpha = Math.Normalize(creditCardRequest.Color.A, 0, 255),
                }
            };
        }
    }
}
