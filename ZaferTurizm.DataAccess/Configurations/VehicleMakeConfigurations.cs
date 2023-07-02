using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleMakeConfigurations : IEntityTypeConfiguration<VehicleMake>
    {
        public void Configure(EntityTypeBuilder<VehicleMake> builder)
        {
            builder.ToTable("VehicleMake");
            builder.HasKey(x => x.Id);//Normalde bunu otamamtik yapıyor
            builder.Property(make => make.Name).IsRequired().HasColumnType("varchar(50)");//Bunu otomatik yapamıyor.

            builder.HasData(
                new VehicleMake() { Id = 1, Name = "Mercedes" },
                new VehicleMake() { Id = 2, Name = "MAN" },
                new VehicleMake() { Id = 3, Name = "Neoplan" },
                new VehicleMake() { Id = 4, Name = "Otokar" },
                new VehicleMake() { Id = 5, Name = "Volvo" });


        }
    }
}
