using CarSeller.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSeller.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Criar tabela User
        builder.ToTable("User");
        
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
            .HasMaxLength(100);

        // Email
        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);
        
        // Password
        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);
        
        // Bio
        builder.Property(x => x.Bio)
            .IsRequired(false)
            .HasColumnName("Bio")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500);

        // Slug
        builder.Property(x => x.Slug);
        // Index Slug
        builder.HasIndex(x => x.Slug, "IX_User_Slug")
            .IsUnique();

        // Image
        builder.Property(x => x.Image);

    }
}