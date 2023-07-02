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
    public class VehicleDefinitionConfiguration : IEntityTypeConfiguration<VehicleDefintion>
    {
        public void Configure(EntityTypeBuilder<VehicleDefintion> builder)
        {
            builder.ToTable(nameof(VehicleDefintion));
            builder.HasKey(x => x.Id);
            
            builder.HasOne(make => make.VehicleModel).WithMany().HasForeignKey(entity => entity.VehicleModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
               VehicleDefintionData.Data01_MercedesTravego2020,
               VehicleDefintionData.Data02_MercedesTravego2021,
               VehicleDefintionData.Data03_ManFortuna2019);
        }
    }
}
