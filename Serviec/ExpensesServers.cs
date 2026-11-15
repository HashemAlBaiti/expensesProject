using expensesProject.DTOs;
using expensesProject.Model;
using expensesProject.Repostory.Base;
using expensesProject.Server.Base;

namespace expensesProject.Server
{
    public class ExpensesServers : IExpensesServers
    {
        IUnitOfwork _unitOfwork;
        public ExpensesServers(IUnitOfwork unitOfwork)
        {
             _unitOfwork = unitOfwork;
        }

        public int? Add(Expenses? expenses)
        {
            
            if (expenses == null)
            {
                return null;
            }

            _unitOfwork.Expenses.AddOne(expenses);
            int? Number=_unitOfwork.Commitchanges();

            return Number;
        }

        public async Task<Expenses?> Delete(int Id)
        {
            Expenses? expenses = await _unitOfwork.Expenses.FindByIdAsync(Id);

            if (expenses == null)
            {
                return null;
            }

            _unitOfwork.Expenses.DeleteOne(expenses);
            _unitOfwork.Commitchanges();

            return expenses;    
        }

        public async Task<IEnumerable<ExpensesRequstDtos>> GetAll()
        {
            return await _unitOfwork.Expenses.GetSelected(null, q => new ExpensesRequstDtos
            {
                Id = q.Id,
                Amount = q.Amount,
                ExpenseDate = q.ExpenseDate,
                titile = q.titile,
                Notes = q.Notes,
                UserName = q.User!.Name,
                PaymentMethodName = q.PaymentMethod!.Name,
                CategoriesName = q.Catigory!.Name,
                UserCardEmail = q.User.UserCards.Email,
                UserCardPhone = q.User.UserCards.Phone,
            }, q => q.OrderBy(k => k.User!.Name));

        }

        

        public async Task<IEnumerable<ExpensesRequstDtos>> GetByCategoryId(int CatgoryId)
        {
            return await _unitOfwork.Expenses.GetSelected(q => q.CatigoryId == CatgoryId, q => new ExpensesRequstDtos
            {
                Id = q.Id,
                Amount = q.Amount,
                ExpenseDate = q.ExpenseDate,
                titile = q.titile,
                Notes = q.Notes,
                UserName = q.User!.Name,
                PaymentMethodName = q.PaymentMethod!.Name,
                CategoriesName = q.Catigory!.Name,
                UserCardEmail = q.User.UserCards.Email,
                UserCardPhone = q.User.UserCards.Phone,
            }, q => q.OrderBy(k => k.User!.Name));
        }


        public async Task<IEnumerable<ExpensesRequstDtos>> GetByPaymentMethodId(int PaymentId)
        {
            return await _unitOfwork.Expenses.GetSelected(q => q.PaymentMethodId == PaymentId, q => new ExpensesRequstDtos
            {
                Id = q.Id,
                Amount = q.Amount,
                ExpenseDate = q.ExpenseDate,
                titile = q.titile,
                Notes = q.Notes,
                UserName = q.User!.Name,
                PaymentMethodName = q.PaymentMethod!.Name,
                CategoriesName = q.Catigory!.Name,
                UserCardEmail = q.User.UserCards.Email,
                UserCardPhone = q.User.UserCards.Phone,
            }, q => q.OrderBy(k => k.User));
        }

        public async Task<IEnumerable<ExpensesRequstDtos>?> GetByUserId(int userId)
        {
            return await _unitOfwork.Expenses.GetSelected(q=> q.UserId==userId,q=> new ExpensesRequstDtos
            {
                Id = q.Id,
                Amount =q.Amount,
                ExpenseDate=q.ExpenseDate,
                titile=q.titile,
                Notes=q.Notes,
                UserName=q.User!.Name,
                PaymentMethodName=q.PaymentMethod!.Name,
                CategoriesName=q.Catigory!.Name,
                UserCardEmail=q.User.UserCards.Email,
                UserCardPhone=q.User.UserCards.Phone,
            }, q=>q.OrderBy(k=> k.User!.Name));


        }

        public async Task<IEnumerable<ExpensesRequstDtos>?> GetByUserName(string userName)
        {
            return await _unitOfwork.Expenses.GetSelected(q => q.User.Name.StartsWith(userName), q => new ExpensesRequstDtos
            {
                Id=q.Id,
                Amount = q.Amount,
                ExpenseDate = q.ExpenseDate,
                titile = q.titile,
                Notes = q.Notes,
                UserName = q.User!.Name,
                PaymentMethodName = q.PaymentMethod!.Name,
                CategoriesName = q.Catigory!.Name,
                UserCardEmail=q.User.UserCards.Email,
                UserCardPhone=q.User.UserCards.Phone,
            }, q=>q.OrderBy(k=> k.User!.Name));


        }

        public async Task<int?> Update(int Id, Expenses? expenses)
        {
            Expenses? exp= await _unitOfwork.Expenses.FindByIdAsync(Id);

            if (expenses == null)
            {
                return null;
            }

            exp!.titile = expenses.titile;
            exp.Notes = expenses.Notes;
            exp.Amount = expenses.Amount;
            exp.ExpenseDate = expenses.ExpenseDate;
            exp.UserId = expenses.UserId;
            exp.PaymentMethodId = expenses.PaymentMethodId;
            exp.CatigoryId = expenses.CatigoryId;
            exp.Name = expenses.Name;

           int Number= _unitOfwork.Commitchanges();

            return Number;
        }

       
    }
}
