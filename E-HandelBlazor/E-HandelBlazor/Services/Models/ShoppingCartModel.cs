using Blazored.LocalStorage;
using Blazored.Toast.Services;
using E_Handel.Dtos;
using E_HandelBlazor.Services.Interfaces;

namespace E_HandelBlazor.Services.Models
{
    public class ShoppingCartModel : IShoppingCart
    {
       
        private readonly ILocalStorageService _localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService;
        private readonly IToastService _toastService;

        public ShoppingCartModel(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddShoppingCart(ShoppingCartDto model)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDto>>("carrito");
                if (cart == null)
                    cart = new List<ShoppingCartDto>();

                var found = cart.FirstOrDefault(c => c.Product.IdProduct== model.Product.IdProduct); 

                if (found != null) 
                    cart.Remove(found);


                cart.Add(model);
                await _localStorageService.SetItemAsync("carrito", cart);
                if (found != null)
                    _toastService.ShowSuccess("Product was updated in the cart");
                else
                    _toastService.ShowSuccess("Product was added to the cart");


               ShowItems.Invoke();


            }
            catch (Exception ex)
            {
                _toastService.ShowError("Could not add in the cart");
            }
        }

        public int Amount()
        {
            var cart = _syncLocalStorageService.GetItem<List<ShoppingCartDto>>("carrito");
            return cart == null ? 0 : cart.Count();
        }

        public async Task CleanShoppingCart()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            ShowItems.Invoke();
        }

        public async Task DeleteShoppingCart(int idProduct)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDto>>("carrito");
                if (cart != null)
                {
                    var element = cart.FirstOrDefault(c => c.Product.IdProduct == idProduct);
                    if (element != null)
                    {
                        cart.Remove(element);
                        await _localStorageService.SetItemAsync("carrito", cart);
                        ShowItems.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {
                // Logga eller hantera undantaget här
                throw new Exception("Error deleting item from shopping cart", ex);
            }
        }


      
        public async Task<List<ShoppingCartDto>> GetAllShoppingCart()
        {
            var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDto>>("carrito");
            if(cart == null)
                cart= new List<ShoppingCartDto>();
            return cart;
        }
    }
}
