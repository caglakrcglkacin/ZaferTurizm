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
    public class HumanService : IHumanService
    {
        TourDbContext _tourDbContext;
        public HumanService(TourDbContext tourDbContext)
        {
                _tourDbContext = tourDbContext;
        }
        public CommadResult Create(HumanDto model)
        {
            try
            {
                var human = new HumanInformation()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Cinsiyet = model.Cinsiyet,
                    Phone = model.Phone,
                    BirhtDay = model.BirhtDay,  
                    Mail = model.Mail,
                    Kimlik = model.Kimlik
                };
                _tourDbContext.Add(human);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();
               
            }
        }

        public CommadResult Delete(HumanDto model)
        {
            try
            {
                var human = new HumanInformation()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Cinsiyet = model.Cinsiyet,
                    Phone = model.Phone,
                    BirhtDay = model.BirhtDay,
                    Mail = model.Mail,
                    Kimlik = model.Kimlik
                };
                _tourDbContext.Remove(human);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                var human = new HumanInformation()
                {
                    Id =Id
                };
                _tourDbContext.Remove(human);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }

        public IEnumerable<HumanDto> GetAll()
        {
            try
            {
              return  _tourDbContext.humanInformations.Select(model => new HumanDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Cinsiyet = model.Cinsiyet,
                    Phone = model.Phone,
                    BirhtDay = model.BirhtDay,
                    Mail = model.Mail,
                  Kimlik = model.Kimlik
              }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return new List<HumanDto>();    
            }
        }

        public HumanDto GetById(int Id)
        {
            try
            {
              var human =  _tourDbContext.humanInformations.Find(Id);
                if (human == null)
                {
                    return null;
                }
                var humanDto = new HumanDto()
                {
                    Id = human.Id,
                    Name = human.Name,
                    Surname = human.Surname,
                    Cinsiyet = human.Cinsiyet,
                    Phone = human.Phone,
                    BirhtDay = human.BirhtDay,
                    Mail = human.Mail,
                    Kimlik = human.Kimlik
                };
                return humanDto;
            }
            catch (Exception ex)
            {


                Trace.TraceError(ex.ToString());
                return new HumanDto();
            }
        }

        public HumanDto? GetByIdent(string KimlikId)
        {
            try
            {
                
                var human = _tourDbContext.humanInformations.FirstOrDefault(x=>x.Kimlik == KimlikId);
                if (human == null)
                {
                    return null;
                }
                var humanDto = new HumanDto()
                {
                    Id = human.Id,
                    Name = human.Name,
                    Surname = human.Surname,
                    Cinsiyet = human.Cinsiyet,
                    Phone = human.Phone,
                    BirhtDay = human.BirhtDay,
                    Mail = human.Mail,
                    Kimlik = human.Kimlik
                };
                return humanDto;
            }
            catch (Exception ex)
            {


                Trace.TraceError(ex.ToString());
                return new HumanDto();
            };
        }

        public CommadResult Update(HumanDto model)
        {
            try
            {
                var human = new HumanInformation()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Cinsiyet = model.Cinsiyet,
                    Phone = model.Phone,
                    BirhtDay = model.BirhtDay,
                    Mail = model.Mail,
                    Kimlik = model.Kimlik
                };
                _tourDbContext.Update(human);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }
    }
}
