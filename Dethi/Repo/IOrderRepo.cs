using Dethi.Model;

namespace Dethi.Repo
{
    public interface IOrderRepo
    {
       public Order findorderbyId(int id);
    }
}
