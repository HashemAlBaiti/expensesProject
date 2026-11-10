using expensesProject.Model;

namespace expensesProject.Serviec.Base
{
    public interface ICatrgoryServes
    {
        Task<IEnumerable<Catigory>> GetAll();

        Task<Catigory> GetById(int Id);
        int? Add(Catigory? Catigorys);

        Task<int?> Update(int Id, Catigory? Catigorys);

        Task<Catigory> Delete(int Id);
    }
}
