using Money;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Shop
{
    public class IAPManager : IStoreListener
    {
        private const string EpicChestID = "1";
        private const string LuckyChestId = "2";

        private IStoreController _controller;
        private IExtensionProvider _extensionProvider;
        private MoneyCounter _moneyCounter;
        
        public IAPManager(MoneyCounter moneyCounter)
        {
            _moneyCounter = moneyCounter;
            SetupBuilder();
        }

        public void BuyProduct(string productID) => _controller?.InitiatePurchase(productID);

        public ProductInfo Get(string productID)
        {
            Product product = _controller.products.WithID(productID);
            ProductInfo productInfo = new ProductInfo();
            productInfo.Id = productID;
            productInfo.Price = product.metadata.localizedPriceString;
            return productInfo;
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            _extensionProvider = extensions;
        }
        
        public void OnInitializeFailed(InitializationFailureReason error) => Debug.LogError("Initialization failed: " + error);

        public void OnInitializeFailed(InitializationFailureReason error, string message) => Debug.LogError("Purchase failed" + error);

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            string productID = purchaseEvent.purchasedProduct.definition.id;
            PayoutDefinition payoutDefinition = purchaseEvent.purchasedProduct.definition.payout;
            int paySum = (int)payoutDefinition.quantity;

            switch (productID)
            {
                case LuckyChestId:
                {
                    _moneyCounter.AddMoney(paySum);
                    break;
                }
                case EpicChestID:
                {
                    _moneyCounter.AddMoney(paySum);
                    break;
                }
                default:
                    Debug.LogError("That ID doesn't expected");
                    break;
            }

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) => Debug.LogError("Purchase failed: " + failureReason);

        private void SetupBuilder()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(EpicChestID, ProductType.Consumable);
            builder.AddProduct(LuckyChestId, ProductType.Consumable);
            
            UnityPurchasing.Initialize(this, builder);
        }
    }

    public class ProductInfo
    {
        public string Id;
        public string Price;
    }
}