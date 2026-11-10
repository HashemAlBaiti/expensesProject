

using expensesProject.Model;
using expensesProject.Repostory.Base;

namespace expensesProject.Repostory.Base
{
    public interface IUnitOfwork:IDisposable
    {
        IRepostory<User> Users { get; }
        IRepostory<PaymentMethod> PaymentMethods { get; }
        IRepostory<Expenses>? Expenses { get; }
        IRepostory<Catigory> Catigories { get; }
        IRepostory<UserCards> UserCards { get; }

        int Commitchanges();
    }
}
