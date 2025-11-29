using BookStore.Models;

namespace BookStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if books already exist
            if (context.Books.Any())
            {
                return; // DB has been seeded
            }

            var books = new Book[]
            {
                new Book
                {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Description = "A classic novel of the Jazz Age, exploring themes of idealism, resistance to change, social upheaval, and excess.",
                    Price = 12.99m,
                    Category = "Fiction",
                    ImageUrl = "https://images.pexels.com/photos/1275235/pexels-photo-1275235.jpeg",
                    StockQuantity = 15
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "A gripping story of racial injustice and childhood innocence in the American South.",
                    Price = 14.50m,
                    Category = "Fiction",
                    ImageUrl = "https://images.pexels.com/photos/1370298/pexels-photo-1370298.jpeg",
                    StockQuantity = 10
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian social science fiction novel about totalitarian control and surveillance.",
                    Price = 11.25m,
                    Category = "Science Fiction",
                    ImageUrl = "https://images.pexels.com/photos/3747468/pexels-photo-3747468.jpeg",
                    StockQuantity = 8
                },
                new Book
                {
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Description = "A fantasy novel about the adventures of hobbit Bilbo Baggins.",
                    Price = 16.75m,
                    Category = "Fantasy",
                    ImageUrl = "https://images.pexels.com/photos/1274980/pexels-photo-1274980.jpeg",
                    StockQuantity = 12
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Description = "A romantic novel of manners that depicts the emotional development of protagonist Elizabeth Bennet.",
                    Price = 10.99m,
                    Category = "Romance",
                    ImageUrl = "https://images.pexels.com/photos/1370295/pexels-photo-1370295.jpeg",
                    StockQuantity = 20
                },
                new Book
                {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Description = "A controversial novel following teenage protagonist Holden Caulfield.",
                    Price = 13.45m,
                    Category = "Fiction",
                    ImageUrl = "https://images.pexels.com/photos/1370296/pexels-photo-1370296.jpeg",
                    StockQuantity = 5
                },
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Author = "J.K. Rowling",
                    Description = "The first novel in the Harry Potter series following a young wizard.",
                    Price = 18.99m,
                    Category = "Fantasy",
                    ImageUrl = "https://images.pexels.com/photos/1370297/pexels-photo-1370297.jpeg",
                    StockQuantity = 25
                },
                new Book
                {
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    Description = "A mystery thriller novel that follows symbologist Robert Langdon.",
                    Price = 15.30m,
                    Category = "Mystery",
                    ImageUrl = "https://images.pexels.com/photos/1274981/pexels-photo-1274981.jpeg",
                    StockQuantity = 18
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
