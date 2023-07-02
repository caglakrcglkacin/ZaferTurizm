using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    public class RotaConfigrations : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable(nameof(Rota));
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.DonusProvince).WithMany().HasForeignKey(p => p.DonusId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.GidisProvince).WithMany().HasForeignKey(p => p.GidisId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
