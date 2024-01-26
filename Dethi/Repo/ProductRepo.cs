using Dethi.Data;
using Dethi.Model;

namespace Dethi.Repo
{
    public class ProductRepo
    {
        private readonly MyDb _myDb;
        public ProductRepo(MyDb myDb)
        {
            _myDb = myDb;
        }
        public Product findbyId(int id)
        {
            return _myDb.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
