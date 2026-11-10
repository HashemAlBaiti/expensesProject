using expensesProject.Model;
using expensesProject.Repostory.Base;
using expensesProject.Serviec.Base;

namespace expensesProject.Serviec
{
    public class PaymentMethodServiec : IPaymentMethodServiec
    {
        IUnitOfwork _unitOfwork;
        public PaymentMethodServiec(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public int? Add(PaymentMethod? PaymentMethods)
        {
            if (PaymentMethods == null)
            {
                return null;
            }

            _unitOfwork.PaymentMethods.AddOne(PaymentMethods);
            int? Number = _unitOfwork.Commitchanges();

            return Number;
        }
        

        public async Task<PaymentMethod> Delete(int Id)
        {
            PaymentMethod? PaymentMethods = await _unitOfwork.PaymentMethods.FindByIdAsync(Id);

            if (PaymentMethods == null)
            {
                return null;
            }

            _unitOfwork.PaymentMethods.DeleteOne(PaymentMethods);
            _unitOfwork.Commitchanges();

            return PaymentMethods;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            return await _unitOfwork.PaymentMethods.GetAllAsync();
        }

        public async Task<PaymentMethod> GetById(int PaymentMethodsId)
        {
            return await _unitOfwork.PaymentMethods.FindByIdAsync(PaymentMethodsId);
        }

        public async Task<int?> Update(int Id, PaymentMethod? PaymentMethods)
        {
            PaymentMethod? Payment= await _unitOfwork.PaymentMethods.FindByIdAsync(Id);

            if (Payment == null)
            {
                return null;
            }

            Payment.Name = PaymentMethods.Name;

            int Number = _unitOfwork.Commitchanges();

            return Number;
        }
    }
}
