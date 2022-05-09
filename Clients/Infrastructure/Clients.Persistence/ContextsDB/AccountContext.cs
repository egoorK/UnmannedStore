using System;
using Microsoft.EntityFrameworkCore;
using Clients.Domain.Entities;
//using Clients.Persistence.Configuration;

namespace Clients.Persistence.ContextsDB
{
    public class AccountContext : DbContext
    {
      
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }

        public AccountContext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.0.109;Port=7001;Database=ClientsDB;Username=pstgrsqluser;Password=pstgrs3381");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountContext).Assembly);

            modelBuilder.Entity<Account>().HasData(
                new Account[]
                {
                    new Account { Account_ID = new Guid("C370B962-0EB5-404C-B3D6-8373B79FEB92"), Username = "Владимир",
                                  Email = "vladimiR@mail.ru", Date_of_Birth = new DateTime(1987, 7, 20),  // год - месяц - день,
                                  Phone_number = "89763547685" },

                    new Account { Account_ID = new Guid("817D8895-4A86-4D83-9CAB-44C6ADDA1E99"), Username = "Евгений",
                                  Email = "zhenya@mail.ru", Date_of_Birth = new DateTime(1990, 8, 11),
                                  Phone_number = "89981329864" },

                    new Account { Account_ID = new Guid("DF52BCA9-3E33-489E-8CE5-CD665C163589"), Username = "Екатерина",
                                  Email = "katty@mail.ru", Date_of_Birth = new DateTime(1995, 1, 2),
                                  Phone_number = "89807432312" }
                });

            modelBuilder.Entity<UserDevice>().HasData(
                new UserDevice[]
                {
                    new UserDevice { Device_ID = new Guid("BFD88510-B501-411D-A7D0-6BC6C2A77956"), Brand = "Huawei",
                                  Model = "P50 Pro", Screen_resolution_height = 2700,
                                  Screen_resolution_width = 1228 },

                    new UserDevice { Device_ID = new Guid("581BE8EC-E28E-4085-92F5-072EBC28AE58"), Brand = "Samsung",
                                  Model = "Galaxy S21", Screen_resolution_height = 2400,
                                  Screen_resolution_width = 1080 },

                    new UserDevice { Device_ID = new Guid("501EDFCC-641D-4343-8A5C-C46B817A2980"), Brand = "Xiaomi",
                                  Model = "Mi 11 Lite", Screen_resolution_height = 2400,
                                  Screen_resolution_width = 1080 }
                });

        }
    }
}
