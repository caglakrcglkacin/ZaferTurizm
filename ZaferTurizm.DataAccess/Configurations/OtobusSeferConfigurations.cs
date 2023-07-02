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
    public class OtobusSeferConfigurations : IEntityTypeConfiguration<OtobusSefer>
    {
        public void Configure(EntityTypeBuilder<OtobusSefer> builder)
        {
            builder.ToTable(nameof(OtobusSefer));
            builder.HasKey(p=>p.Id);
            builder.Property(trip => trip.Tarih).HasColumnType("datetime2(0)");
            builder.Property(p => p.Fiyat).HasColumnType("money"); 
            builder.HasOne(p => p.vehicleDefintion).WithMany().HasForeignKey(p => p.VehicleDefintionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.rota).WithMany().HasForeignKey(p => p.RotaId).OnDelete(DeleteBehavior.NoAction);
           
        }
    }
}
