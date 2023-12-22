﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Primary Key
            builder.HasKey(u => u.Id);

            // Alanlar
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            // İlişkiler
            builder.HasMany(u => u.Pets)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
