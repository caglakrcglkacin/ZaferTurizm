
using ZaferTurizm.Domain;


namespace ZaferTurizm.Dtos
{
    public class VehicleModelDto
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
       
    }
}
