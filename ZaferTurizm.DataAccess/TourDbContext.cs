using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.Configurations;
using ZaferTurizm.DataAccess.Settings;
using ZaferTurizm.Domain;


namespace ZaferTurizm.DataAccess
{
    public class TourDbContext:DbContext
    {
        public TourDbContext()
        {

        }

        public TourDbContext(DbContextOptions op):base (op)
        {

        }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<VehicleDefintion> VehicleDefinitions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<HumanInformation> humanInformations { get; set; }
        public DbSet<OtobusSefer> OtobusSefers { get; set; }
        public DbSet<Bilet> Bilets { get; set; }
        //yaptığımız configurastionu buraya implamant etmemiz gerekmektedir.Onuda override onmodelcreating dememiz gerekmektedir.ve bunuda modelbuuilderın içinde 
        //applyconfigurationa tanımlamamız gerekmektedir.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMakeConfigurations());
            modelBuilder.ApplyConfiguration(new VehicleModelConfigurations());
            modelBuilder.ApplyConfiguration(new ProvinceConfigurations());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new RotaConfigrations());
            modelBuilder.ApplyConfiguration(new HumanConfigurations());
            modelBuilder.ApplyConfiguration(new OtobusSeferConfigurations());
            modelBuilder.ApplyConfiguration(new BiletConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(DbSetting.DbConnectionString);///Constand olduğu için dbsetting sınıfından almamıza gerek yok
        }
    }
}
