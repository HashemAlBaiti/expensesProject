using expensesProject.DTOs;
using expensesProject.Model;

namespace expensesProject.Serviec.Base
{
    public interface IPaymentMethodServiec
    {
        Task<IEnumerable<PaymentMethod>> GetAll();

        Task<PaymentMethod> GetById(int userId);
        int? Add(PaymentMethod? User);

        Task<int?> Update(int Id, PaymentMethod? User);

        Task<PaymentMethod> Delete(int Id);
    }
}
