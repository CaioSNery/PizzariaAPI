using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Models;


namespace Pizzaria.Map
{
    public class PizzaMap : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizzas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Sabor).IsRequired();

            builder.Property(p => p.ValorPizza).IsRequired();

            builder.Property(p => p.ValorPizza)
            .HasColumnType("decimal(18,2)");


        }


    }
}