using expensesProject.DTOs;
using expensesProject.Model;

namespace expensesProject.Server.Base
{
    public interface IExpensesServers
    {
        Task<IEnumerable<ExpensesRequstDtos>> GetAll();

        Task<IEnumerable<ExpensesRequstDtos>> GetByUserId(int userId);
        Task<IEnumerable<ExpensesRequstDtos>> GetByUserName(string UserName);

        Task<IEnumerable<ExpensesRequstDtos>> GetByCategoryId(int CatgoryId);
        Task<IEnumerable<ExpensesRequstDtos>> GetByPaymentMethodId(int PaymentId);

        int? Add(Expenses? expenses);

        Task<int?> Update(int Id, Expenses? expenses);

        Task<Expenses> Delete(int Id);

    }
}
