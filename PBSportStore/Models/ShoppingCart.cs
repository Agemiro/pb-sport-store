using Microsoft.EntityFrameworkCore;
using PBSportStore.Context;

namespace PBSportStore.Models;
public class ShoppingCart
{
    private readonly AppDbContext _context;

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public static ShoppingCart GetCart (IServiceProvider services) 
    {
        //Define uma seção
        ISession session = 
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            
        //Obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();

        //Obtem ou gera o Id do carrinho
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        //Atribui o id do carrinho na Sessão
        session.SetString("CartId", cartId);

        //Retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new ShoppingCart(context)
        {
            ShoppingCartId = cartId,
        };
    }

    public void AddToCart(Product product)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
            s => s.Product.ProductId == product.ProductId &&
            s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Product = product,
                Quantity = 1
            };
            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Quantity++;
        }
        _context.SaveChanges();
    }

    public int RemoveToCart(Product product)
    {
        var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
            s => s.Product.ProductId == product.ProductId &&
            s.ShoppingCartId == ShoppingCartId);

        var localQuantity = 0;

        if (shoppingCartItem != null)
        {
            if(shoppingCartItem.Quantity > 1)
            {
                shoppingCartItem.Quantity--;
                localQuantity = shoppingCartItem.Quantity;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        _context.SaveChanges();
        return localQuantity;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??
            (ShoppingCartItems =
                _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Product)
                .ToList());
    }

    public void ClearCart()
    {
        var cartItems = _context.ShoppingCartItems
                        .Where(cart => cart.ShoppingCartId == ShoppingCartId);

        _context.ShoppingCartItems.RemoveRange(cartItems);
        _context.SaveChanges();
    }

    public decimal GetTotalShoppingCartValue()
    {
        var total = _context.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Select(c => c.Product.Price * c.Quantity).Sum();

        return total;
    }
}

