using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public class RotaService : IRotaService
    {
        TourDbContext _tourDbContext;
        public RotaService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommadResult Create(RotaDto model)
        {
            try
            {
                var entity = new Rota()
                {
                    GidisId = model.GidisId,
                    DonusId = model.VarisYonuId
                };
                _tourDbContext.Add(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public CommadResult Delete(RotaDto model)
        {
            try
            {
                var entity = new Rota()
                {
                    Id =model.Id,
                    GidisId = model.GidisId,
                    DonusId = model.VarisYonuId
                };
                _tourDbContext.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            };
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                var entity = new Rota()
                {
                    Id =Id
                   
                };
                _tourDbContext.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            };
        }

        public IEnumerable<RotaDto> GetAll()
        {
            try
            {
              return  _tourDbContext.Rotas.Select(p => new RotaDto()
                {
                    Id = p.Id,
                    GidisId = p.GidisId,
                    VarisYonuId = p.DonusId
                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public RotaDto? GetById(int Id)
        {
            try
            {
              return  _tourDbContext.Rotas.Select(p => new RotaDto()
                {
                    Id = p.Id,
                    GidisId = p.GidisId,
                    VarisYonuId = p.DonusId

                }).SingleOrDefault();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<RotaSummary> GetDefintId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RotaSummary> GetSummary()
        {

            try
            {
                return _tourDbContext.Rotas.Select(p => new RotaSummary()
                {
                    Id = p.Id,
                    GidisYonu = p.GidisProvince.Name,
                    VarisYonu = p.DonusProvince.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public CommadResult Update(RotaDto model)
        {
            try
            {
                var entity = new Rota()
                {
                    Id = model.Id,
                    GidisId = model.GidisId,
                    DonusId = model.VarisYonuId
                };
                _tourDbContext.Update(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return null;
            };
        }
    }
}
