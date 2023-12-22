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
    public class ActivitiesConfiguration : IEntityTypeConfiguration<Activities>
    {
        public void Configure(EntityTypeBuilder<Activities> builder)
        {
            // Primary Key
            builder.HasKey(a => a.Id);

            // Enumlar için yapılandırmalar
            builder.Property(a => a.ActivityType)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(a => a.Effect)
                .HasConversion<int>()
                .IsRequired();

            // Alanlar
            builder.Property(a => a.Description)
                .HasMaxLength(500);

            builder.Property(a => a.StartTime)
                .IsRequired();

            builder.Property(a => a.EndTime)
                .IsRequired();

            // İlişkiler
            builder.HasOne(a => a.Pet)
                .WithMany(p => p.Activities)
                .HasForeignKey(a => a.PetId);
        }
    }
}
