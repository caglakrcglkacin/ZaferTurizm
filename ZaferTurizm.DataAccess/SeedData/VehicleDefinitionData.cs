using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class VehicleDefintionData
    {
        /// <summary>
        /// Mercedes Travego 2020
        /// </summary>
        public readonly static VehicleDefintion Data01_MercedesTravego2020 = new VehicleDefintion()
        {
            Id = 1,
            VehicleModelId = VehicleModelData.Data01_MercedesTravego.Id,
            Year = 2020,
            SeatCount = 48,
            HasTailet = false,
            HasWifi = true
        };

        /// <summary>
        /// Mercedes Travego 2021
        /// </summary>
        public static readonly VehicleDefintion Data02_MercedesTravego2021 = new VehicleDefintion()
        {
            Id = 2,
            VehicleModelId = VehicleModelData.Data01_MercedesTravego.Id,
            Year = 2021,
            SeatCount = 48,
            HasTailet = false,
            HasWifi = true
        };

        public static readonly VehicleDefintion Data03_ManFortuna2019 = new VehicleDefintion()
        {
            Id = 3,
            VehicleModelId = VehicleModelData.Data05_ManFortuna.Id,
            Year = 2019,
            SeatCount = 52,
            HasTailet = false,
            HasWifi = false
        };
    }
}
