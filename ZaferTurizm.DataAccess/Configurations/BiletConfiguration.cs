using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    public class BiletConfiguration : IEntityTypeConfiguration<Bilet>
    {
        public void Configure(EntityTypeBuilder<Bilet> builder)
        {
            builder.ToTable(nameof(Bilet));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Price).IsRequired().HasColumnType("money");
            builder.Property(p => p.VerildigiTarihi).IsRequired().HasColumnType("datetime");
            builder.HasOne(p=>p.Kisi).WithMany().HasForeignKey(entity => entity.HumanId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.SeferBilgisi).WithMany().HasForeignKey(entity => entity.SeferId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
