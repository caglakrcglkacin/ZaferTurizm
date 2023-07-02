using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;
using VehicleMake = ZaferTurizm.Domain.VehicleMake;

namespace ZaferTurizm.Bussiness.Services
{
    //Commad = creat,update,delete
    //Query = Read
    //Magic Value
    //QueryResult = Arastır
    //Parametre = metotta tanımlanmıs,dışarıdan gelen degerleri karşılayaak olan değişken
    //Argüman = parametreye gönderilmiş değer
    public class _VehicleMakeService : _IVehicleMakeService
    {
        TourDbContext _database;
        public _VehicleMakeService(TourDbContext database)
        {
            _database = database;
        }
        public CommadResult Create(VehicleMakeDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new VehicleMake()
                {
                    Name = model.Name
                };
                _database.VehicleMakes.Add(VehicleMakes);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }

        }

        public CommadResult Delete(VehicleMakeDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new VehicleMake()
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _database.VehicleMakes.Remove(VehicleMakes);
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

                var VehicleMakes = new VehicleMake()
                {
                    Id = Id

                };


                _database.VehicleMakes.Remove(VehicleMakes);
                _database.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            //_database.Set<VehicleMake>().ToList();
            //Base Service varsa set metotı kullanıyor.Dbset gönderiliyor.
            //var vehicleMakeList = _database.VehicleMakes.ToList();
            //var vehicleMakeDtos = new List<VehicleMakeDto>();
            //foreach (var vehicleMake in vehicleMakeList)
            //{
            //    vehicleMakeDtos.Add(new VehicleMakeDto()
            //    {
            //        Id = vehicleMake.Id,
            //        Name = vehicleMake.Name,
            //    });
            //}
            //return vehicleMakeDtos;
            try
            {
                return _database.VehicleMakes.Select(vm => new VehicleMakeDto()
                {
                    Id = vm.Id,
                    Name = vm.Name
                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                //tekil bi kayıt için kaydın olma durumdan Instance boş olma durumda null
                //Koleksiyon tipindeki vir veri için verinin olma durumunda Instance (1 veya birden fazla kayıt içerir şekilde)
                //Verinin olmama durumu boş koleksiyon
                return Enumerable.Empty<VehicleMakeDto>();//boş kleksiyon gönderme sekli
            }
        }

        public VehicleMakeDto GetById(int Id)
        {
            try
            {
                var vehicleMake = _database.VehicleMakes.Find(Id);
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
                var yeni = new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name
                };
                return yeni;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }

        }

        public CommadResult Update(VehicleMakeDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new VehicleMake()
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _database.VehicleMakes.Update(VehicleMakes);
                _database.SaveChanges();
                return CommadResult.Success();

                //var vehicleMake = _database.VehicleMakes.Find(model.Id);
                //vehicleMake.Name= model.Name;
                //_database.SaveChanges();
                //var vehicleMake = new VehicleMake()
                //{
                //    Id = model.Id,
                //    Name = model.Name
                //};
                //var entity = _database.Attach(vehicleMake);
                //entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //_database.SaveChanges();



            }
            catch (Exception ex)
            {
                return CommadResult.Failure();
            }
        }
    }
}
