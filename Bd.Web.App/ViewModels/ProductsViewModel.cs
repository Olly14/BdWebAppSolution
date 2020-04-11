using Bd.Web.App.Models;
using Bd.Web.App.ViewModels;
using System.Collections.ObjectModel;


namespace Bd.web.App.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        public ProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
          
        }

        public ObservableCollection<ProductModel> Products { get; set; }
    }
}
