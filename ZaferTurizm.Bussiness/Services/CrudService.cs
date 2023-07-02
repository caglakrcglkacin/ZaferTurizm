using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Bussiness.Services
{
    public abstract class CrudService<TDto, TSummary, TEntity> : ICrudService<TDto, TSummary>
        where TEntity : class, IEntity, new()
    {

        protected readonly TourDbContext _tourDbContext;
        public CrudService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        protected abstract TEntity MapToEntity(TDto model);
        protected abstract Expression<Func<TEntity,TDto>> DtoMapper { get; }
        protected abstract Expression<Func<TEntity, TSummary>> SummaryMapper { get; }
        public CommadResult Create(TDto model)
        {
            try
            {
                var entity = MapToEntity(model);
                _tourDbContext.Set<TEntity>().Add(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(TDto model)
        {
            try
            {
                var entity = MapToEntity(model);
                _tourDbContext.Set<TEntity>().Remove(entity);
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
                var entity = new TEntity() { Id = Id };
                if (entity != null)
                {
                    _tourDbContext.Set<TEntity>().Remove(entity);
                    _tourDbContext.SaveChanges();
                    return CommadResult.Success();
                }
                else
                {
                    return CommadResult.Failure("Kayıt bulunamadı.");
                }
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();
            }
        }

        public IEnumerable<TDto> GetAll()
        {
            try
            {
                return _tourDbContext.Set<TEntity>()
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TDto>();
            }
        }

        public TDto? GetById(int Id)
        {
            try
            {
                //var dtoMapper = new Func<TEntity, TDto>(MapToDto);

                return _tourDbContext.Set<TEntity>()
                    .Where(entity => entity.Id == Id)
                    .Select(DtoMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public IEnumerable<TSummary> GetSummary()
        {
            try
            {
                //var summaryMapper = new Func<TEntity, TSummary>(MapToSummary);

                return _tourDbContext.Set<TEntity>()
                    .Select(SummaryMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TSummary>();
            }
        }

        public TSummary? GetSummaryById(int id)
        {
            try
            {
                return _tourDbContext.Set<TEntity>()
                    .Where(entity => entity.Id == id)
                    .Select(SummaryMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public CommadResult Update(TDto model)
        {
            try
            {
                var entity = MapToEntity(model);
                _tourDbContext.Set<TEntity>().Update(entity);
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

