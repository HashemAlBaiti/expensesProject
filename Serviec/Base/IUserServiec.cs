using expensesProject.DTOs;
using expensesProject.Model;
using System.Threading.Tasks;

namespace expensesProject.Serviec.Base
{
    public interface IUserServiec
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int userId);
        int? Add(User? User);

        Task<int?> Update(int Id, User? User);

        Task<User> Delete(int Id);
    }
}
