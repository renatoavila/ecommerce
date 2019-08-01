using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Business.Interface
{
    public class StockBusiness : IStockBusiness
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public StockBusiness(IStockRepository stockRepository,
                             IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }

        public void StockKepping(Product product, int AmountStock)
        {
            product.Id = GetProductId(product);
            var stockProduct = _stockRepository.GetByProduct(product.Id);
            if ((stockProduct == null) ||
               (stockProduct.Id == 0))
            {
                stockProduct = new Stock();
                stockProduct.productId = product.Id;
                stockProduct.AmountStock = AmountStock;
                stockProduct.AmountReserved = 0;
                _stockRepository.Insert(stockProduct);
            }
            else
            {
                stockProduct.AmountStock += AmountStock;
                _stockRepository.Update(stockProduct);
            }
        }
        public void PaymentStock(ItemCart item)
        {
            PaymentStock(item.product, item.Amount);
        }
        public void PaymentStock(Product product, int amount)
        {
            product.Id = GetProductId(product);
            var stockProduct = _stockRepository.GetByProduct(product.Id);

            //Existe produto no stock
            if ((stockProduct != null) ||
                (stockProduct.Id > 0))
            {
                stockProduct.AmountReserved -= amount;
                stockProduct.AmountStock -= amount;
                _stockRepository.Update(stockProduct);
            }
        }
        public bool ReservedStock(ItemCart item)
        {
            return ReservedStock(item.product, item.Amount);
        }
        public bool ReservedStock(Product product, int amount)
        {
            product.Id = GetProductId(product);
            var stockProduct = _stockRepository.GetByProduct(product.Id);

            //Existe produto no stock
            if ((stockProduct == null) ||
                (stockProduct.Id == 0) ||
                (stockProduct.AmountStock < stockProduct.AmountReserved + amount))
            {
                return false;
            }
            else
            {
                stockProduct.AmountReserved += amount;
                return _stockRepository.Update(stockProduct);
            }
        }
        public void ReverseStock(ItemCart item)
        {
            ReverseStock(item.product, item.Amount);
        }
        public void ReverseStock(Product product, int amount)
        {
            product.Id = GetProductId(product);
            var stockProduct = _stockRepository.GetByProduct(product.Id);

            //Existe produto no stock
            if ((stockProduct != null) &&
                (stockProduct.Id != 0))
            {
                stockProduct.AmountReserved -= amount;
                _stockRepository.Update(stockProduct);
            }
        }
        private long GetProductId(Product product)
        {
            return _productRepository.Get(product.Key)?.Id ?? 0;
        }
    }
}
