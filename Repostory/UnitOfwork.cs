


using expensesProject.Data;
using expensesProject.Model;
using expensesProject.Repostory.Base;
using Microsoft.EntityFrameworkCore;
using Repostory.Repostory;

namespace expensesProject.Repostory
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly AppDbContext _context;
         
        public UnitOfwork(AppDbContext context)
        {
            _context = context;

            Users = new MainRepostory<User>(context);
            Catigories= new MainRepostory<Catigory>(context);
            PaymentMethods= new MainRepostory<PaymentMethod>(context);
            Expenses= new MainRepostory<Expenses>(context);
            UserCards= new MainRepostory<UserCards>(context);
        }

        public IRepostory<User> Users { get; private set; }

        public IRepostory<PaymentMethod> PaymentMethods { get; private set; }

        public IRepostory<Expenses> Expenses { get; private set; }

        public IRepostory<Catigory> Catigories { get; private set; }

        public IRepostory<UserCards> UserCards { get; private set; }

        public int Commitchanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    

    }
}
