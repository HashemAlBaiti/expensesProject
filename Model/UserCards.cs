using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace expensesProject.Model
{
    public class UserCards
    {
        [Key]
        public int Id { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }


      




    }
}
