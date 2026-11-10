using System.Text.Json.Serialization;

namespace expensesProject.Model
{
    public class PaymentMethod : BaseElement
    {
        [JsonIgnore]
        public ICollection<Expenses>? Expenses { get; set; }
    }
}
