using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace expensesProject.Model
{
    public class Expenses:BaseElement
    {
        [MaxLength(1000)]
        public string? titile { get; set; }
        public string? Notes { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
      
        public User? User { get; set; }
        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
     
        public PaymentMethod? PaymentMethod { get; set; }
        public int CatigoryId { get; set; }

        [ForeignKey("CatigoryId")]
        
        public Catigory? Catigory { get; set; }

       
    }
}
