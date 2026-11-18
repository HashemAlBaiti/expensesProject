using expensesProject.Model;
using expensesProject.Repostory.Base;
using expensesProject.Serviec.Base;

namespace expensesProject.Serviec
{
    public class UserServiec : IUserServiec
    {
        IUnitOfwork _unitOfwork;
        public UserServiec(IUnitOfwork unitOfwork)
        {
             _unitOfwork=unitOfwork;
        }

        public int? Add(User? User)
        {
            if (User == null)
            {
                return null;
            }

            _unitOfwork.Users.AddOne(User);
            int? Number = _unitOfwork.Commitchanges();

            return Number;
        }

        public async Task<User> Delete(int Id)
        {
            User? Users = await _unitOfwork.Users.FindByIdAsync(Id);
            


            if (Users == null)
            {
                return null;
            }
            UserCards? UserCards = await _unitOfwork.UserCards.FindByIdAsync(Users.UserCardsId);


            _unitOfwork.UserCards.DeleteOne(UserCards);
            _unitOfwork.Users.DeleteOne(Users);
            _unitOfwork.Commitchanges();

            return Users;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfwork.Users.GetAllAsync("UserCards");
        }

        public async Task<User> GetById(int userId)
        {
            return await _unitOfwork.Users.FindByIdAsync(userId);
        }

        public async Task<int?> Update(int Id, User? User)
        {
            User? Use = await _unitOfwork.Users.FindByIdAsync(Id, "UserCards");

            if (Use == null)
            {
                return null;
            }

            //Use.UserCardsId = User.UserCardsId;
            Use.Name = User.Name;
            Use.UserCards.Email=User.UserCards.Email;
            Use.UserCards.Phone=User.UserCards.Phone;

            int Number = _unitOfwork.Commitchanges();

            return Number;
        }
    }
}
