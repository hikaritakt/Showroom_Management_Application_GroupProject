using Microsoft.EntityFrameworkCore;
                    .OnDelete(DeleteBehavior.Restrict);
            });

modelBuilder.Entity<Color>(entity =>
{
    entity.ToTable("Color");
    entity.HasKey(x => x.ColorId);
    entity.Property(x => x.ColorId).HasColumnName("color_id");
    entity.Property(x => x.ColorName).HasColumnName("color_name").HasMaxLength(50).IsRequired();
});

modelBuilder.Entity<CarStatus>(entity =>
{
    entity.ToTable("CarStatus");
    entity.HasKey(x => x.StatusId);
    entity.Property(x => x.StatusId).HasColumnName("status_id");
    entity.Property(x => x.StatusName).HasColumnName("status_name").HasMaxLength(50).IsRequired();
});

modelBuilder.Entity<CarInventoryTransaction>(entity =>
{
    entity.ToTable("CarInventoryTransaction");
    entity.HasKey(x => x.TransactionId);
    entity.Property(x => x.TransactionId).HasColumnName("transaction_id");
    entity.Property(x => x.CarId).HasColumnName("car_id");
    entity.Property(x => x.TransactionType).HasColumnName("transaction_type").HasMaxLength(10).IsRequired();
    entity.Property(x => x.Quantity).HasColumnName("quantity");
    entity.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(18,2)");
    entity.Property(x => x.Note).HasColumnName("note").HasMaxLength(255);
    entity.Property(x => x.TransactionDate).HasColumnName("transaction_date");

    entity.HasOne(x => x.Car)
        .WithMany(x => x.CarInventoryTransactions)
        .HasForeignKey(x => x.CarId)
        .OnDelete(DeleteBehavior.Restrict);
});

modelBuilder.Entity<Accessory>(entity =>
{
    entity.ToTable("Accessory");
    entity.HasKey(x => x.AccessoryId);
    entity.Property(x => x.AccessoryId).HasColumnName("accessory_id");
    entity.Property(x => x.AccessoryName).HasColumnName("accessory_name").HasMaxLength(100).IsRequired();
    entity.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(18,2)");
    entity.Property(x => x.Quantity).HasColumnName("quantity");
    entity.Property(x => x.Description).HasColumnName("description").HasMaxLength(255);
});

modelBuilder.Entity<AccessoryInventoryTransaction>(entity =>
{
    entity.ToTable("AccessoryInventoryTransaction");
    entity.HasKey(x => x.AccessoryTransactionId);
    entity.Property(x => x.AccessoryTransactionId).HasColumnName("accessory_transaction_id");
    entity.Property(x => x.AccessoryId).HasColumnName("accessory_id");
    entity.Property(x => x.TransactionType).HasColumnName("transaction_type").HasMaxLength(10).IsRequired();
    entity.Property(x => x.Quantity).HasColumnName("quantity");
    entity.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(18,2)");
    entity.Property(x => x.Note).HasColumnName("note").HasMaxLength(255);
    entity.Property(x => x.TransactionDate).HasColumnName("transaction_date");

    entity.HasOne(x => x.Accessory)
        .WithMany(x => x.AccessoryInventoryTransactions)
        .HasForeignKey(x => x.AccessoryId)
        .OnDelete(DeleteBehavior.Restrict);
});

modelBuilder.Entity<CarAccessory>(entity =>
{
    entity.ToTable("CarAccessory");
    entity.HasKey(x => x.CarAccessoryId);
    entity.Property(x => x.CarAccessoryId).HasColumnName("car_accessory_id");
    entity.Property(x => x.CarId).HasColumnName("car_id");
    entity.Property(x => x.AccessoryId).HasColumnName("accessory_id");
    entity.Property(x => x.Quantity).HasColumnName("quantity");

    entity.HasOne(x => x.Car)
        .WithMany(x => x.CarAccessories)
        .HasForeignKey(x => x.CarId)
        .OnDelete(DeleteBehavior.Cascade);

    entity.HasOne(x => x.Accessory)
        .WithMany(x => x.CarAccessories)
        .HasForeignKey(x => x.AccessoryId)
        .OnDelete(DeleteBehavior.Restrict);
});
        }
    }
}