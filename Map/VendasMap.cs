using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzaria.Models;


namespace Pizzaria.Map
{
    public class VendasMap : IEntityTypeConfiguration<Vendas>
    {
        public void Configure(EntityTypeBuilder<Vendas> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Pizza)
            .WithMany()
            .HasForeignKey(v => v.PizzaId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}