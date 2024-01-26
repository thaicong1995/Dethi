using Dethi.Data;
using Dethi.Model;

namespace Dethi.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly MyDb _myDb;
        public OrderRepo(MyDb myDb)
        {
            _myDb = myDb;
        }

        public Order findorderbyId(int id)
        {
            return _myDb.Orders.FirstOrDefault(p => p.Id == id);
        }
    }
}
