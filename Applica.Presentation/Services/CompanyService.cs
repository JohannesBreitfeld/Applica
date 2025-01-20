using Applica.Domain.Entities;
using Applica.Infrastructure.Context;
using Applica.Presentation.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Applica.Presentation.Services;

public class CompanyService
{
    private readonly MongoContext _context;

    public CompanyService(MongoContext context)
    {
        _context = context;
    }

    public async Task<ObservableCollection<CompanyVM>> GetAllAsync()
    {
        var companies = await _context.Companies.ToListAsync();

        return new ObservableCollection<CompanyVM>(companies.Select(MapToModel));
    }

    public async Task AddAsync(CompanyVM company)
    {
        var entity = MapToEntity(company);

        await _context.AddAsync(entity);

        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(CompanyVM company)
    {
        var entity = await _context.Companies.FindAsync(company.Id);

        if(entity is not null)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(CompanyVM company)
    {
        var existingCompany = await _context.Companies.FindAsync(company.Id);

        if(existingCompany is not null)
        {
            existingCompany = MapToEntity(company);
            await _context.SaveChangesAsync();
        }
    }

    private CompanyVM MapToModel(Company company)
    {
        var model = new CompanyVM()
        {
            Id = company.Id,
            Name = company.Name,
            Url = company.Url,
            Activities = (ObservableCollection<ActivityVM>)company!.Activities!.Select(a => new ActivityVM()
            {
                Id = a.Id,
                Category = new ActivityCategoryVM() { Id = a.Category.Id, Description = a.Category.Description },
                Description = a.Description,
                Date = a.Date,
                FollowUpDate = a.FollowUpDate
            }),
            Comments = (ObservableCollection<CommentVM>)company!.Comments!.Select(c => new CommentVM()
            {
                Id = c.Id,
                Label = c.Label,
                Content = c.Content,
                Date = c.Date
            }),
            ContactPeople = (ObservableCollection<ContactPersonVM>)company!.ContactPeople!.Select(cp => new ContactPersonVM()
            {
                Id = cp.Id,
                Name = cp.Name,
                Phone = cp.Phone,
                Email = cp.Email
            })
        };

        return model;
    }

    private Company MapToEntity(CompanyVM company)
    {
        var entity = new Company()
        {
            Id = company.Id,
            Name = company.Name,
            Url = company.Url,
            Activities = company!.Activities!.Select(a => new Activity()
            {
                Id = a.Id,
                Category = new ActivityCategory() { Id = a.Category.Id, Description = a.Category.Description },
                Description = a.Description,
                Date = a.Date,
                FollowUpDate = a.FollowUpDate
            }).ToList(),
            Comments = company!.Comments!.Select(c => new Comment()
            {
                Id = c.Id,
                Label = c.Label,
                Content = c.Content,
                Date = c.Date
            }).ToList(),
            ContactPeople = company!.ContactPeople!.Select(cp => new ContactPerson()
            {
                Id = cp.Id,
                Name = cp.Name,
                Phone = cp.Phone,
                Email = cp.Email
            }).ToList()
        };

        return entity;
    }
}
    //    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    //    {
    //        protected readonly MongoContext _context;
    //        protected readonly DbSet<TEntity> _dbSet;

    //        public Repository(MongoContext context)
    //        {
    //            this._context = context;
    //            _dbSet = _context.Set<TEntity>();
    //        }

    //        public virtual async Task AddAsync(TEntity entity)
    //        {
    //            await _dbSet.AddAsync(entity);
    //            await _context.SaveChangesAsync();
    //        }

    //        public virtual async Task DeleteAsync(TEntity entity)
    //        {
    //            var id = entity.Id;
    //            var ent = await _dbSet.FindAsync(id);
    //            if (ent != null)
    //            {
    //                _dbSet.Remove(ent);
    //                await _context.SaveChangesAsync();
    //            }
    //        }

    //        public virtual async Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
    //        {
    //            var entities = await _dbSet.ToListAsync();

    //            return entities.Where(predicate).AsEnumerable();
    //        }

    //        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    //        {
    //            return await _dbSet.ToListAsync();
    //        }

    //        public virtual async Task<TEntity?> GetByIdAsync(string id)
    //        {
    //             return await _dbSet.FindAsync(id);

    //        }