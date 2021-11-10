using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controller.Models
{
    public class MobileContext: DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        //public MobileContext()
        //{
        //    Database.EnsureCreated();
        //}
        // второй вариант настройки контекста. Первый  - регистрация в виде сервиса в Startup
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
        //}
    }
}
