using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace Fina.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {   // Tabela e chave primaria
        builder.ToTable("Category");
        builder.HasKey(x => x.Id);

        // Config das Colunas da tabela
        builder.Property(x => x.Title).IsRequired(true).HasColumnType("NVARCHAR").HasMaxLength(80);
        builder.Property(x => x.Description).IsRequired(false).HasColumnType("NVARCHAR").HasMaxLength(255);
        builder.Property(x => x.UserId).IsRequired(true).HasColumnType("VARCHAR").HasMaxLength(160);
    }

    
    
}
