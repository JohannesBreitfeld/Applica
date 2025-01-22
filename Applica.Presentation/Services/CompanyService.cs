using Applica.Domain.Entities;
using Applica.Infrastructure.Context;
using Applica.Presentation.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Applica.Presentation.Services;

public class CompanyService
{
    public async Task<ObservableCollection<CompanyVM>> GetAllAsync()
    {
        using (var context = new MongoContext())
        {
            var companies = await context.Companies.ToListAsync();

            return new ObservableCollection<CompanyVM>(companies.Select(MapToModel));
        }
    }

    public async Task AddAsync(CompanyVM company)
    {
        using (var context = new MongoContext())
        {
            var entity = MapToEntity(company);

            await context.AddAsync(entity);

            await context.SaveChangesAsync();
        }

    }

    public async Task DeleteAsync(CompanyVM company)
    {
        using (var context = new MongoContext())
        {
            var entity = await context.Companies.FindAsync(company.Id);

            if (entity is not null)
            {
                context.Remove(entity);

                await context.SaveChangesAsync();
            }
        }
    }

    public async Task UpdateAsync(CompanyVM company)
    {
        using (var context = new MongoContext())
        {
            var existingCompany = await context.Companies.FindAsync(company.Id);

            if (existingCompany is not null)
            {
                var mapped = MapToEntity(company);

                existingCompany.Name = mapped.Name;
                existingCompany.Url = mapped.Url;
                existingCompany.Comments = mapped.Comments;
                existingCompany.Activities = mapped.Activities;
                existingCompany.ContactPeople = mapped.ContactPeople;

                await context.SaveChangesAsync();
            }
        }
    }

    private CompanyVM MapToModel(Company company)
    {
        var model = new CompanyVM()
        {
            Id = company.Id,
            Name = company.Name,
            Url = company.Url,
            Activities = company?.Activities != null
                ? new ObservableCollection<ActivityVM>(
                    company.Activities.Select(a => new ActivityVM()
                    {
                        Id = a.Id,
                        Category = a.Category,
                        Description = a.Description,
                        Date = a.Date,
                        FollowUpDate = a.FollowUpDate
                    }))
                : new ObservableCollection<ActivityVM>(),
            Comments = company?.Comments != null
                ? new ObservableCollection<CommentVM>(
                    company.Comments.Select(c => new CommentVM()
                    {
                        Id = c.Id,
                        Label = c.Label,
                        Content = c.Content,
                        Date = c.Date
                    }))
                : new ObservableCollection<CommentVM>(), 
            ContactPeople = company?.ContactPeople != null
                ? new ObservableCollection<ContactPersonVM>(
                    company.ContactPeople.Select(cp => new ContactPersonVM()
                    {
                        Id = cp.Id,
                        Name = cp.Name,
                        Phone = cp.Phone,
                        Email = cp.Email
                    }))
                : new ObservableCollection<ContactPersonVM>()
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
                Category = a.Category,
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