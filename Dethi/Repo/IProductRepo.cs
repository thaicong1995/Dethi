using Dethi.Model;

namespace Dethi.Repo
{
    public interface IProductRepo
    {
        public Product findbyId(int id);
    }
}
