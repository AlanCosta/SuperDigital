using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.IO.Domain.ContaCorrente;
using SuperDigital.IO.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Infra.Data.Mappings
{
    public class ContaCorrenteMapping : EntityTypeConfiguration<ContaCorrente>
    {
        public override void Map(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder
                .Property(e => e.NumeroConta)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(e => e.ValorTotalConta)
                .HasColumnType("float")
                .IsRequired();

            builder
                .Ignore(e => e.ValidationResult);
            builder
                .Ignore(e => e.CascadeMode);

            builder
                .ToTable("tb_ContaCorrenteSuperDigital");
        }
    }
}
