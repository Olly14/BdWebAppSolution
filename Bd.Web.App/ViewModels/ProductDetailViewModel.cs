//using Bd.Web.App.Models;
//using Bd.Web.App.ViewModels;
//using System.Collections.Generic;

//namespace Bd.web.App.ViewModels
//{
//    public class ProductDetailViewModel : BaseViewModel
//    {
//        public ProductViewModel _product;

//        public ProductDetailViewModel(ProductViewModel productModel = null)
//        {
//            _product = productModel?? new ProductViewModel();
//        }

//        public string ProductModelId
//        {
//            get{
//                return _product.ProductId;
//            }
//            set{
//                _product.ProductId = value;
//            }
//        }

//        public string ProductModelName {
//            get {
//                return _product.Name;
//            }
//            set {
//                _product.Name = value;
//            }
//        }

//        public string ProductModelDescription
//        {
//            get{
//                return _product.Description;
//            }
//            set{
//                _product.Description = value;
//            }
//        }

//        public bool ProductModelIsBlocked
//        {
//            get{
//                return _product.IsBlocked;
//            }
//            set{
//                _product.IsBlocked = value;
//            }
//        }

//        public bool ProductModelIsDeleted
//        {
//            get{
//                return _product.IsDeleted;
//            }
//            set{
//                _product.IsDeleted = value;
//            }
//        }

//        public double ProductModelPrice
//        {
//            get{
//                return _product.Price;
//            }
//            set{
//                _product.Price = value;
//            }
//        }

//        public List<OrderItemViewModel> ProductModelOrderItems
//        {
//            get{
//                return _product.OrderItems;
//            }
//            set{
//                _product.OrderItems = value;
//            }
//        }

//        public string ProductUriKey
//        {
//            get
//            {
//                return _product.UriKey;
//            }
//            set
//            {
//                _product.UriKey = value;
//            }
//        }
//    }
//}
