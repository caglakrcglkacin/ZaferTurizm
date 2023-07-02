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
    public class HumanConfigurations : IEntityTypeConfiguration<HumanInformation>
    {
        public void Configure(EntityTypeBuilder<HumanInformation> builder)
        {
            builder.ToTable(nameof(HumanInformation));
            builder.HasKey(p=>p.Id);
            builder.Property(pass => pass.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(pass => pass.Surname).IsRequired().HasColumnType("varchar(50)");
            builder.Property(pass => pass.Kimlik).IsRequired().HasColumnType("varchar(15)");
        }
    }
}
