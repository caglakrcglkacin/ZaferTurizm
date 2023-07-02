using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class RotaData
    {
        public static readonly Rota Data01_IzmirIstanbul = new Rota()
        {
            Id = 1,
            GidisId = CityData.Data01_Adana.Id,
            DonusId = CityData.Data03_Afyon.Id
        };

        public static readonly Rota Data02_IstanbulAnkara = new Rota()
        {
            Id = 2,
            GidisId = CityData.Data33_Gaziantep.Id,
            DonusId = CityData.Data65_Rize.Id
        };

        public static readonly Rota Data03_IstanbulAntalya = new Rota()
        {
            Id = 3,
            GidisId = CityData.Data79_Yalova.Id,
            DonusId = CityData.Data62_Niğde.Id
        };

        public static readonly Rota Data04_AnkaraIzmir = new Rota()
        {
            Id = 4,
            GidisId = CityData.Data65_Rize.Id,
            DonusId = CityData.Data05_Aksaray.Id
        };
    }
}
