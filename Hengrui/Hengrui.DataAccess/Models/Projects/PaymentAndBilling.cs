using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hengrui.DataAccess.Models.Projects
{
    public class PaymentAndBilling
    {
        public int Id { get; set; }

        public PayBase Payment { get; set; }

        public PayBase Billing { get; set; }
    }

    [ComplexType]
    public class PayBase
    {
        private bool _isValid;

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                if (!value)
                {
                    Date = null;
                    Amount = 0;
                }
            }
        }

        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }
    }
}