﻿using System.Drawing;

namespace WebTools.Requests.CreditCard {
    public abstract class BaseCreditCardRequest {
        public string Name { get; set; }
        public float Limit { get; set; }
        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly PaymentDay { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public Color Color { get; set; }
    }
}
