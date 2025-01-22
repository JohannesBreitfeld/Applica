using Applica.Domain.Entities;
using Applica.Infrastructure.Context;
using Applica.Presentation.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Applica.Presentation.Services
{
    public class CategoryService
    {
        public async Task<ObservableCollection<ActivityCategoryVM>> GetAllAsync()
        {
            using (var context = new MongoContext())
            {
                var categories = await context.ActivityCategories.ToListAsync();

                return new ObservableCollection<ActivityCategoryVM>(categories.Select(MapToModel));
            }
        }

        public async Task AddAsync(ActivityCategoryVM category)
        {
            using (var context = new MongoContext())
            {
                var entity = MapToEntity(category);

                await context.AddAsync(entity);

                await context.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(ActivityCategoryVM category)
        {
            using (var context = new MongoContext())
            {
                var entity = await context.ActivityCategories.FindAsync(category.Id);

                if (entity is not null)
                {
                    context.Remove(entity);

                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(ActivityCategoryVM newValue, string oldValue)
        {
            using (var context = new MongoContext())
            {
                var existingCategory = await context.ActivityCategories.FindAsync(newValue.Id);

                if (existingCategory is not null)
                {
                    var mapped = MapToEntity(newValue);

                    existingCategory.Description = mapped.Description;

                    var companyService = new CompanyService();

                    var companies = await companyService.GetAllAsync();

                    foreach (var company in companies)
                    {
                        foreach (var activity in company.Activities)
                        {
                            if(activity?.Category == oldValue)
                            {
                                activity.Category = newValue.Description;
                                
                                await companyService.UpdateAsync(company);

                            }
                        }
                    }

                    await context.SaveChangesAsync();
                }
                else
                {
                    await AddAsync(newValue);
                }
            }
        }

        private ActivityCategoryVM MapToModel(ActivityCategory entity)
        {
            var model = new ActivityCategoryVM
            {
                Id = entity.Id,
                Description = entity.Description
            };

            return model;
        }
        private ActivityCategory MapToEntity(ActivityCategoryVM model)
        {
            var entity = new ActivityCategory
            {
                Id = model.Id,
                Description = model.Description
            };

            return entity;
        }
    }
}
