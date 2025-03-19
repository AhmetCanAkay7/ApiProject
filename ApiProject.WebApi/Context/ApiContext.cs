﻿using ApiProject.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebApi.Context;
// This class is used to connect to the database
public class ApiContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-TO26F5B\\SQLEXPRESS;initial catalog=ApiYummyDb;" +
                                    "integrated security=true;TrustServerCertificate=True");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}