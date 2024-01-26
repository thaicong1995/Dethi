using Dethi.Data;
using Dethi.Dto;
using Dethi.Model;
using Dethi.Sevice.Iservice;

namespace Dethi.Sevice.Service
{
    public class ProductService : IProductService
    {
        private readonly MyDb _myDb;
        public ProductService(MyDb myDb)
        {
            _myDb = myDb;
        }
        public Product AddNew(ProductDto productDto)
        {
            try
            {
                if(productDto is null)
                {
                    throw new ArgumentNullException(nameof(productDto), "Product data cannot be null.");
                }
                Product newProduct = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    Quantity = productDto.Quantity,
               };
                _myDb.Add(newProduct);
                _myDb.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error {ex}");
            }
        }

    }
}
