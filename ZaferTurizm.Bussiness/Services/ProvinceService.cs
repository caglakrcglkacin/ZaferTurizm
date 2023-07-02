using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Bussiness.Services
{
    public class ProvinceService : IProvinceService
    {
        TourDbContext _tourDbContext;
        public ProvinceService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommadResult Create(ProvinceDto model)
        {
            try
            {
                var entity = new Province()
                {
                    Name = model.Name
                    
                };
                _tourDbContext.Add(entity); 
                _tourDbContext.SaveChanges();
                return  CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(ProvinceDto model)
        {
            try
            {
                var entity = new Province()
                {
                    Id=model.Id,
                    Name = model.Name

                };
                _tourDbContext.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                var entity = new Province()
                {
                    Id = Id
                  

                };
                _tourDbContext.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public IEnumerable<ProvinceDto> GetAll()
        {
            try
            {
                return _tourDbContext.Provinces.Select(p => new ProvinceDto()
                {
                    Id = p.Id,
                    Name = p.Name

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
               
                return Enumerable.Empty<ProvinceDto>();
            }
           
        }

        public ProvinceDto GetById(int Id)
        {
            var Il = _tourDbContext.Provinces.Find(Id);
            if (Il == null)
            {
                return null;

            }
            var ilBul = new ProvinceDto()
            {
                Id = Il.Id,
                Name = Il.Name

            };
            return ilBul;
        }
        public CommadResult Update(ProvinceDto model)
        {
            try
            {
                var entity = new Province()
                {
                    Id = model.Id,
                    Name = model.Name

                };
                _tourDbContext.Update(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }
    }
}
