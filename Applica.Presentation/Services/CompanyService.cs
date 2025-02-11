using Applica.Domain.Entities;
using Applica.Infrastructure.Context;
using Applica.Presentation.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Forms;

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

    public async Task AddRangeAsync(ICollection<CompanyVM> companies)
    {
        using (var context = new MongoContext())
        {
            var mapped = companies.Select(MapToEntity).ToList();

            await context.AddRangeAsync(mapped);

            await context.SaveChangesAsync();

        }

    }

    public async Task<ObservableCollection<CompanyVM>> FindAsync(Expression<Func<Company, bool>> predicate)
    {
        var companies = new ObservableCollection<CompanyVM>();
        
        using (var context = new MongoContext())
        {
            var results = await context.Companies
                .Where(predicate)
                .ToListAsync();

            companies = new ObservableCollection<CompanyVM>(results.Select(MapToModel));
        }
        return companies;
    }

    public async Task<int> GetCountAsync(Expression<Func<Company, bool>> predicate)
    {
        using (var context = new MongoContext())
        {
            return await context.Companies
                .Where(predicate)
                .CountAsync();
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

            if(existingCompany is null)
            {
                await AddAsync(company);
                return;
            }

            var mapped = MapToEntity(company);

            existingCompany.Name = mapped.Name;
            existingCompany.Url = mapped.Url;
            existingCompany.Comments = mapped.Comments;
            existingCompany.Activities = mapped.Activities;
            existingCompany.ContactPeople = mapped.ContactPeople;

            await context.SaveChangesAsync();
            
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
