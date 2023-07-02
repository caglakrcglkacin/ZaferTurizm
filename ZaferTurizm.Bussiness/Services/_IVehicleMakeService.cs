using ZaferTurizm.Dtos;

namespace ZaferTurizm.Bussiness.Services
{
    //Crud:Creat,Read,Update,Delete
    public interface _IVehicleMakeService
    {
        CommadResult Create(VehicleMakeDto model);
        CommadResult Update(VehicleMakeDto model);
        CommadResult Delete(VehicleMakeDto model);
        CommadResult Delete(int Id);

        //Read
        VehicleMakeDto GetById(int Id);
        IEnumerable<VehicleMakeDto> GetAll();
       
    }
}
