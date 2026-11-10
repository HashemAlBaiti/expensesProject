using System.ComponentModel.DataAnnotations;

namespace expensesProject.DTOs
{
    public class ExpensesRequstDtos
    {

        public int Id { get; set; }

        [MaxLength(1000)]
        public string? titile { get; set; }
        public string? Notes { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }

        public string UserName { get; set; }
        public string PaymentMethodName { get; set; }
        public string CategoriesName { get; set; }

        public string UserCardPhone { get; set; }
        public string UserCardEmail { get; set; }

    }
}
