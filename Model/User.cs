using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace expensesProject.Model
{
    public class User:BaseElement
    {


        [JsonIgnore]
        public int UserCardsId { get; set; }

        [ForeignKey("UserCardsId")]
        public UserCards? UserCards { get; set; }
        [JsonIgnore]
        public ICollection<Expenses>? Expenses { get; set; }

       



    }
}
