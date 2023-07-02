using System.Diagnostics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        TourDbContext _database;
        public VehicleModelService(TourDbContext database)
        {
            _database = database;
        }

        public CommadResult Create(VehicleModelDto model)
        {
            try
            {
                //Mapping

                var VehicleModel = new VehicleModel()
                {
                    Name = model.Name,
                    VehicleMakeId=model.VehicleMakeId
                   
                   
                };
                _database.VehicleModels.Add(VehicleModel);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(VehicleModelDto model)
        {
            try
            {
                //Mapping

                var VehicleModel = new VehicleModel()
                {
                    Id = model.Id,
                    Name = model.Name,                    
                    VehicleMakeId = model.VehicleMakeId
                };
                _database.VehicleModels.Remove(VehicleModel);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                //Mapping

                var VehicleModel = new VehicleModel()
                {
                    Id = Id,
                  
                };
                _database.VehicleModels.Remove(VehicleModel);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {
            return _database.VehicleModels.Select(vm => new VehicleModelDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                VehicleMakeId=vm.VehicleMakeId
            }).ToList();
        }

        public VehicleModelDto GetById(int Id)
        {
            try
            {
                var vehicleMake = _database.VehicleModels.Find(Id);
                //find = db set üzerinden Pk değeri üzerinden ile bir kaydı bulmaya yarayan metot
                //Single = yazılan metoda göre 1 kayıdı bulmadı
                //singleorDefault = yazılan metoda göre 1 veya hiç kayıt olmalı 
                //first = yazılan kriter karşılığında mjutlaka 1 veya daha fazla kayıt olmalı 
                //bu kayıtlatdan 1.cini sabitler
                //last = kayıt bulmalı hiç kayıt olmamlı 
                //FirstOrDefault asyc = aynı anlamda birden fazla iş yapmaya yarıyor. 
                //Await = derlendiğinde bu kısım kopartılıyor. bekleme yapıyor. bu sayede asyc yapıyor
                //özetle = linq metotlarında tekil kayıt döndürmeye yarayan single,first,last metotlarının.
                //filtre kriterine yazdığınız ifadenin kayıt dönmeme ihtimali varsa ordefault kulanın
                //Aşağıda singileordefaul örnektekiyle yukarıda örnek aynı işi yapıyor.Sentaks olarak çağırma farkı var 
                //vehicleMake = _database.VehicleMakes.SingleOrDefault(p=>p.Id == Id);
                if (vehicleMake == null)
                {
                    return null;
                }
                var yeni = new VehicleModelDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name,
                    VehicleMakeId=vehicleMake.VehicleMakeId
                 
                };
                return yeni;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            { return _database.VehicleModels.Where(dto => dto.VehicleMakeId == vehicleMakeId)
                    .Select(entity => new VehicleModelDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeId = entity.VehicleMakeId
            }).ToList();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleModelDto>();
            }
        }

        public IEnumerable<VehicleModelSummay> GetSummary()
        {
            try
            {
             return   _database.VehicleModels.Select(p => new VehicleModelSummay()
                {
                    Id = p.Id,
                    Name = p.Name,
                    VehicleMakeName = p.VehicleMake.Name

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CommadResult Update(VehicleModelDto model)
        {
            try
            {
                //Mapping

                var VehicleModel = new VehicleModel()
                {
                    Id =model.Id,
                    Name = model.Name,
                    VehicleMakeId = model.VehicleMakeId
                };
                _database.VehicleModels.Update(VehicleModel);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }
    }
}
