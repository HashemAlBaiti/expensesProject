using System.Text.Json.Serialization;

namespace expensesProject.Model
{
    public class Catigory:BaseElement
    {
        [JsonIgnore]
        public ICollection<Expenses>? Expenses { get; set; }
    }
}
