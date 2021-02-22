﻿using Fenicia.Application.Common.Interfaces;
using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Infrastructure.Persistence
{
    public class FeniciaDbContext : DbContext, IFeniciaDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public FeniciaDbContext(DbContextOptions<FeniciaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Number).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.Floor).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.Door).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.ZipCode).IsRequired().HasMaxLength(25);

            modelBuilder.Entity<City>().Property(a => a.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Customer>().Property(a => a.TradeName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.FiscalName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Nif).IsRequired().HasMaxLength(9);
            modelBuilder.Entity<Customer>().Property(a => a.Phone).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Email).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Employee>().Property(e => e.Job).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(8,2)").IsRequired();

            modelBuilder.Entity<Order>().Property(e => e.NumberItems).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Priority).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Status).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Iva).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.TotalPrice).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.EntryDate).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.AssignamentDate).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.TerminationDate).IsRequired();

            modelBuilder.Entity<OrderItem>().Property(e => e.Discount).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e => e.Quantity).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.Dni).HasColumnType("varchar(9)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Surname).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Phone).IsRequired(); 
            modelBuilder.Entity<Person>().HasIndex(p => p.Dni).IsUnique();

            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("text").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Stock).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Iva).HasColumnType("decimal(8,2)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<User>().ToTable("User");
            

        }
    }
}
