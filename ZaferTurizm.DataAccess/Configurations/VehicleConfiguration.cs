using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));
            builder.HasKey(x => x.Id);
            builder.Property(make => make.PlateNumber).IsRequired().HasColumnType("varchar(50)");
            builder.HasOne(make => make.VehicleDefintion).WithMany().HasForeignKey(entity => entity.VehicleDefintionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
               VehicleData.Data01_34ABC123,
               VehicleData.Data02_34CDE654,
               VehicleData.Data03_34QWE345,
               VehicleData.Data04_34ZXC987);
        }
    }
 }

