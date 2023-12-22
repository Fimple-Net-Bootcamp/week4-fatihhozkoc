using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Repository.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Alanlar
            builder.Property(p => p.Species)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Breed)
                .HasMaxLength(50);

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(5, 2)"); 

            // İlişkiler
            builder.HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(p => p.Statutes)
                .WithOne(s => s.Pet)
                .HasForeignKey(s => s.PetId);

            builder.HasMany(p => p.Activities)
                .WithOne(a => a.Pet)
                .HasForeignKey(a => a.PetId);

            builder.HasMany(p => p.Foods)
                .WithOne(f => f.Pet)
                .HasForeignKey(f => f.PetId);
        }
    }
}
