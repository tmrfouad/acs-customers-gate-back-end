using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using acscustomersgatebackend.Models.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace acscustomersgatebackend.Models
{
    public class CustomersGateContext : IdentityDbContext
    {
        public DbSet<RFQ> RFQs { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailSender> EmailSenders { get; set; }

        public CustomersGateContext(DbContextOptions<CustomersGateContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RFQConfiguration());
            modelBuilder.ApplyConfiguration(new RFQActionConfiguration());
            modelBuilder.ApplyConfiguration(new RFQActionAttConfiguration());
            modelBuilder.ApplyConfiguration(new RepresentativeConfigration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEditionConfiguration());
            modelBuilder.ApplyConfiguration(new EmailTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new EmailSenderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}