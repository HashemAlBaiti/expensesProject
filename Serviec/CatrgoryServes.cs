using expensesProject.Model;
using expensesProject.Repostory.Base;
using expensesProject.Serviec.Base;

namespace expensesProject.Serviec
{
    public class CatrgoryServes : ICatrgoryServes
    {
        IUnitOfwork _unitOfwork;
        public CatrgoryServes(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public int? Add(Catigory? Catigorys)
        {
            if (Catigorys == null)
            {
                return null;
            }

            _unitOfwork.Catigories.AddOne(Catigorys);
            int? Number = _unitOfwork.Commitchanges();

            return Number;
        }

        public async Task<Catigory> Delete(int Id)
        {
            Catigory? Catigorys = await _unitOfwork.Catigories.FindByIdAsync(Id);

            if (Catigorys == null)
            {
                return null;
            }

            _unitOfwork.Catigories.DeleteOne(Catigorys);
            _unitOfwork.Commitchanges();

            return Catigorys;
        }

        public async Task<IEnumerable<Catigory>> GetAll()
        {
            return await _unitOfwork.Catigories.GetAllAsync();
        }

        public async Task<Catigory> GetById(int Id)
        {
            return await _unitOfwork.Catigories.FindByIdAsync(Id);
        }

        public async Task<int?> Update(int Id, Catigory? Catigorys)
        {
            Catigory? cat = await _unitOfwork.Catigories.FindByIdAsync(Id);

            if (cat == null)
            {
                return null;
            }

            cat.Name = Catigorys.Name;

            int Number = _unitOfwork.Commitchanges();

            return Number;
        }
    }
}
