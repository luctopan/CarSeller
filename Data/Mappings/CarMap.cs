using CarSeller.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSeller.Data.Mappings;

public class CarMap : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        // Criar tabela Car
        builder.ToTable("Car");
        
        // Definir chave primária
        builder.HasKey(x => x.Id);
        
        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        // Definir as propriedades (colunas) da tabela
        // Name
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        
        // Brand
        builder.Property(x => x.Brand)
            .IsRequired()
            .HasColumnName("Brand")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        
        // Model
        builder.Property(x => x.Model)
            .IsRequired()
            .HasColumnName("Model")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
    
        // Year
        builder.Property(x => x.Year)
            .IsRequired()
            .HasColumnName("Year")
            .HasColumnType("INT");
        
        // Price
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(18,2)");
        
        // Image
        builder.Property(x => x.Image)
            .IsRequired(false)
            .HasColumnName("Image")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);
        
        // CreatedDate
        builder.Property(x => x.CreatedDate)
            .IsRequired()
            .HasColumnName("CreatedDate")
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        // LastUpdateDate
        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("LastUpdateDate")
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        // Relacionamentos
        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}