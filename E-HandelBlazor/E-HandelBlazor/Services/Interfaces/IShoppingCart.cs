using E_Handel.Dtos;

namespace E_HandelBlazor.Services.Interfaces
{
    public interface IShoppingCart
    {
        event Action ShowItems;

        int Amount();

        Task AddShoppingCart(ShoppingCartDto model);
        Task DeleteShoppingCart(int idProduct);
        Task<List<ShoppingCartDto>> GetAllShoppingCart();
        Task CleanShoppingCart();

    }
}
