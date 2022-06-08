using System;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Persitence.ContextsDB
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartContents> CartContents { get; set; }

        public RepositoryContext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.0.109;Port=7003;Database=BasketFormationDB;Username=pstgrsqluser;Password=pstgrs3381");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);

            modelBuilder.Entity<Account>().HasData(
                new Account[]
                {
                    new Account { Account_ID = new Guid("C370B962-0EB5-404C-B3D6-8373B79FEB92"), Username = "Владимир" },

                    new Account { Account_ID = new Guid("817D8895-4A86-4D83-9CAB-44C6ADDA1E99"), Username = "Евгений" },

                    new Account { Account_ID = new Guid("DF52BCA9-3E33-489E-8CE5-CD665C163589"), Username = "Екатерина" }
                });

            modelBuilder.Entity<Account>().HasOne(a => a.Basket).WithOne(b => b.Account); // Установка связи один-к-одному (одна учетная запись имеет одну корзину)

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { Product_ID = new Guid("730b2a39-cb74-4eb0-ab90-43de3970caae"),
                                  Name = "Сывороточный напиток. Мажитэль ананас манго",
                                  Unit_price = 45.60M,
                                  Article_number = "54356375673" },

                    new Product { Product_ID = new Guid("f35200f7-bd6c-4110-b3d3-72f6378634a8"),
                                  Name = "Йогурт. Активиа чернослив",
                                  Unit_price = 78.90M,
                                  Article_number = "988797345" },

                    new Product { Product_ID = new Guid("4eea67a3-9b8c-47a5-b19c-5dac727d7cab"),
                                  Name = "Йогурт. Активиа киви и мюсли",
                                  Unit_price = 79.45M,
                                  Article_number = "56756867" }
                });

            modelBuilder.Entity<Product>().HasMany(a => a.CartContents).WithOne(b => b.Product); // Установка связи один-ко-многим (один товар может находится во многих корзинах)


            //modelBuilder.Entity<ShoppingCart>().HasData(
            //    new ShoppingCart[]
            //    {
            //        new ShoppingCart { ShoppingCart_ID = new Guid("63786dfa-775d-40fb-8649-f519b7a31606"),
            //                      Fill_start_time = new DateTime(2015, 7, 20, 18, 30, 25),
            //                      Fill_end_time = new DateTime(2015, 7, 20, 19, 11, 36),
            //                      Total_without_discount = 609.99M,
            //                      Total_with_discount = 0M,
            //                      AccountID = new Guid("C370B962-0EB5-404C-B3D6-8373B79FEB92")  }
            //    });

            modelBuilder.Entity<ShoppingCart>().HasMany(a => a.CartContents).WithOne(b => b.ShoppingCart).OnDelete(DeleteBehavior.Cascade); ; // Установка связи один-ко-многим (одна корзина может иметь неограниченное количество содержимого)

            //modelBuilder.Entity<CartContents>().HasData(
            //    new CartContents[]
            //    {
            //        new CartContents { CartContents_ID = new Guid("59b7f34b-fc15-4f64-a170-949bf515a2fe"),
            //                      Discount_price = 45.32M,
            //                      Quantity = 1,
            //                      Price_incl_quantity = 45.32M,
            //                      Item_number_in_cart = 1,
            //                      ProductID = new Guid("730b2a39-cb74-4eb0-ab90-43de3970caae"),
            //                      ShoppingCartID = new Guid("63786dfa-775d-40fb-8649-f519b7a31606")  },

            //        new CartContents { CartContents_ID = new Guid("3c2c3537-703c-4b10-9bbc-5e46c6440d65"),
            //                      Discount_price = 129.56M,
            //                      Quantity = 1,
            //                      Price_incl_quantity = 388.68M,
            //                      Item_number_in_cart = 2,
            //                      ProductID = new Guid("f35200f7-bd6c-4110-b3d3-72f6378634a8"),
            //                      ShoppingCartID = new Guid("63786dfa-775d-40fb-8649-f519b7a31606")  },

            //        new CartContents { CartContents_ID = new Guid("a38ae090-64a1-4b17-a3a2-771a354c8a02"),
            //                      Discount_price = 435.11M,
            //                      Quantity = 1,
            //                      Price_incl_quantity = 435.11M,
            //                      Item_number_in_cart = 3,
            //                      ProductID = new Guid("4eea67a3-9b8c-47a5-b19c-5dac727d7cab"),
            //                      ShoppingCartID = new Guid("63786dfa-775d-40fb-8649-f519b7a31606")  }
            //    });
        }
    }
}
