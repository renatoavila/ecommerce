using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;
using System.Linq;

namespace Ecommerce.Business.Interface
{
    public class StockBusiness: IStockBusiness

    {

        private readonly IStockRepository _stockRepository;
      
        public StockBusiness(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
         
        }
        public int ChangeStock(ItemCart item, Operation operation)
        {
            return ChangeStock(item.product, item.Amount, operation);
          
        }
        public int ChangeStock(Product product, int amount, Operation operation)
        {
            var stockProduct = _stockRepository.Get(product.Id);

            //Existe produto no stock
            bool IsStock = stockProduct == null? false: true;

            stockProduct.product = product;
            stockProduct.productId = product.Id;

            switch (operation)
            {
                case Operation.Increment: //Entrada produto
                    stockProduct.AmountStock += amount;
                    break;
                case Operation.NoPayment: //falta de pagamento
                    stockProduct.AmountReserved -= amount;
                    stockProduct.AmountStock += amount;
                    break;
                case Operation.Reserved: //Reservar realizada
                    stockProduct.AmountReserved += amount;
                    break;
                case Operation.Payment: //pagamento realizado
                    stockProduct.AmountReserved -= amount;
                    stockProduct.AmountStock -= amount;
                    break;
            }
            if (IsStock)
            {
                _stockRepository.Update(stockProduct);
            }
            else
            {
                _stockRepository.Insert(stockProduct);
            }
            // retorno do saldo do estoque, se negativo notificar e não permitir
            return (stockProduct.AmountStock - stockProduct.AmountReserved);
        }

    }
}
