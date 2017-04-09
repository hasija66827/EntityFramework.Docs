using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.UWP
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct>OrderProducts  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging4.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.MobileNo)
                .IsUnique() ;

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.BarCode)
                .IsUnique();
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.UserDefinedCode)
                .IsUnique();
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public bool IsVerifiedUser { get; set; }

        public List<Order> Orders { get; set; }

        public Customer(string name, string mobileNo)
        {
            this.CustomerId = Guid.NewGuid();
            this.MobileNo = mobileNo;
            this.Name = name;
            this.IsVerifiedUser = false;
        }
        public Customer() { }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float BillAmount { get; set; }
        public float PaidAmount {get; set;}
        public float WalletSnapShot { get; set; }
        //      public float LeftAmount { get; set; }

        [Required]
        public Nullable<Guid> CustomerId;
        public Customer Customer;

        public List<OrderProduct> OrderProducts { get; set; }

        public Order(Guid customerId, Customer customer)
        {
            this.OrderId = Guid.NewGuid();
            this.OrderDate = DateTime.Now;
            this.CustomerId = customerId;
            this.Customer = customer;
        }
        public Order() { }


    }
    public class Product
    {
        public Guid ProductId { get; set; }
        public string BarCode { get; set; }
        public string UserDefinedCode { get; set; }
        public bool IsInventoryItem { get; set; }
        public Int32 Threshold { get; set; }
        public Int32 RefillTime { get; set; }
        public float DisplayPrice { get; set; }
        public float DiscountPer { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
        public Product()
        {
            this.ProductId = Guid.NewGuid();
            this.Threshold = 0;
            this.RefillTime = 0;
            this.DisplayPrice = 0;
            this.DiscountPer = 0;
        }
    }

    public class OrderProduct
    {
        public Guid OrderProductId { get; set; }
        public int QuantityPurchased { get; set; }
        public float DisplayCostSnapShot { get; set; }
        public float DiscountPerSnapShot { get; set; }

       
        [Required]
        public Nullable<Guid> OrderId;
        public Order Order;

        [Required]
        public Nullable<Guid> ProductId;
        public Product Product;
    }
}

