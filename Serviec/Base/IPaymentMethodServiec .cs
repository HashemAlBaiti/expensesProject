using expensesProject.DTOs;
using expensesProject.Model;

namespace expensesProject.Serviec.Base
{
    public interface IPaymentMethodServiec
    {
        Task<IEnumerable<PaymentMethod>> GetAll();

        Task<PaymentMethod> GetById(int PaymentMethodId);
        int? Add(PaymentMethod? PaymentMethods);

        Task<int?> Update(int Id, PaymentMethod? PaymentMethods);

        Task<PaymentMethod> Delete(int Id);
    }
}
