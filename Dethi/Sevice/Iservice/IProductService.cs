using Dethi.Dto;
using Dethi.Model;

namespace Dethi.Sevice.Iservice
{
    public interface IProductService
    {
        public Product AddNew(ProductDto productDto);
    }
}
