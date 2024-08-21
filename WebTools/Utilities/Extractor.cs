using WebTools.Requests.CreditCard;

namespace WebTools.Utilities
{
    public static class Extractor
    {
        public static Models.Finances.CreditCard GetCreditCardFromRequest(CreateCreditCardRequest createCreditCardRequest)
        {
            return new Models.Finances.CreditCard {
                Id = Guid.NewGuid(),
                Name = createCreditCardRequest.Name,
                Limit = createCreditCardRequest.Limit,
                TotalUsed = 0,
                DueDate = createCreditCardRequest.DueDate.Day,
                PaymentDay = createCreditCardRequest.PaymentDay.Day,
                Color = new Models.Finances.CreditCardColor {
                    Blue = createCreditCardRequest.Color.B,
                    Red = createCreditCardRequest.Color.R,
                    Green = createCreditCardRequest.Color.G,
                    Alpha = Math.Normalize(createCreditCardRequest.Color.A, 0, 255),
                }
            };
        }
    }
}
