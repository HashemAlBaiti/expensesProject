using System.ComponentModel.DataAnnotations;

namespace expensesProject.Model
{
    public class BaseElement
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
