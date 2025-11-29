using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Cart
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        // POST: Cart/Add/5
        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity = 1)
        {
            var book = await _context.Books.FindAsync(id);
            if(book is null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(i => i.BookId == id);
            if(existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    BookId = book.Id,
                    BookTitle = book.Title,
                    Price = book.Price,
                    Quantity = 1,
                    ImageUrl = book.ImageUrl
                });
            }

            SaveCart(cart);
            TempData["Message"] = $"{book.Title} added to cart!";
            return RedirectToAction("Index", "Books");
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }

        // POST: /Cart/Remove/5
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(i => i.BookId == id);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
                TempData["Message"] = $"{itemToRemove.BookTitle} removed from cart!";
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/Update
        [HttpPost]
        public IActionResult Update(int id, int quantity)
        {
            var cart = GetCart();
            var itemToUpdate = cart.FirstOrDefault(i => i.BookId == id);
            if (itemToUpdate != null)
            {
                if (quantity <= 0)
                {
                    cart.Remove(itemToUpdate);
                }
                else
                {
                    itemToUpdate.Quantity = quantity;
                }
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        // GET: /Cart/Checkout
        [HttpPost]
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: /Cart/Checkout
        [HttpPost]
        public async Task<IActionResult> Checkout(string customerName, string email, string address)
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction(nameof(Index));
            }

            var order = new Order
            {
                CustomerName = customerName,
                Email = email,
                Address = address,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(item => item.Price * item.Quantity),
                Status = "Confirmed"
            };

            foreach (var item in cart)
            {
                order.OrderItems.Add(new OrderItem
                {
                    BookId = item.BookId,
                    BookTitle = item.BookTitle,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Cart");

            TempData["Success"] = $"Order #{order.Id} placed successfully!";
            return RedirectToAction("Confirmation", new { id = order.Id });
        }

        // GET: /Cart/Confirmation
        public async Task<IActionResult> Confirmation(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
