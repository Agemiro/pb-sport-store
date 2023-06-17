using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBSportStore.Models;
using PBSportStore.Repositories.Interfaces;

namespace PBSportStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository; 
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            int totalItemsOrder = 0;
            decimal totalPrice = 0.0m;

            //Obtem os itens do carrinho de compra do cliente
            List<ShoppingCartItem> items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            //Verificar se existem itens de pedido
            if(_shoppingCart.ShoppingCartItems.Count == 0){
                ModelState.AddModelError("", "Your cart is empty, how about adding a product...");
            }

            //Calcula o total de itens e o total do pedido
            foreach(var item in items)
            {
                totalItemsOrder += item.Quantity;
                totalPrice += (item.Product.Price * item.Quantity);
            }

            //Atribui os valores obtidos ao pedido
            order.TotalItemsInTheOrder = totalItemsOrder;
            order.TotalOrder = totalPrice;

            //Valida os dados do pedido
            if(ModelState.IsValid) 
            { 
                //Cria o pedido e os detalhes
                _orderRepository.CreateOrder(order);

                //Define mensagens ao cliente
                ViewBag.CompleteMessageCheckout = "Thanks for your order :)";
                ViewBag.TotalOrder = _shoppingCart.GetTotalShoppingCartValue();

                //Limpa o carrinho do cliente
                _shoppingCart.ClearCart();

                //Exibe a view com dados do cliente e do pedido
                return View("~/Views/Order/CompleteCheckout.cshtml", order);
            }

            return View(order);
        }
    }
}
