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
    public class VehicleModelConfigurations : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("VehicleModel");
            builder.HasKey(x => x.Id);//Normalde bunu otamamtik yapıyor
            builder.Property(make => make.Name).IsRequired().HasColumnType("varchar(50)");
            builder.HasData(
                VehicleModelData.Data01_MercedesTravego,
                VehicleModelData.Data02_Mercedes403,
                VehicleModelData.Data03_MercedesTourismo,
                VehicleModelData.Data04_ManLions,
                VehicleModelData.Data05_ManFortuna,
                VehicleModelData.Data06_ManSl);
        }
    }
}
