namespace Applica.Presentation.Resources
{
    using Applica.Presentation.ViewModels.Models;
    using System;
    using System.Collections.ObjectModel;

    public class SampleDataGenerator
    {
        public static ObservableCollection<CompanyVM> GenerateSampleData()
        {
            var companies = new ObservableCollection<CompanyVM>();

            // Företag 1
            var company1 = new CompanyVM
            {
                Name = "Tech Innovations AB",
                Url = "https://www.techinnovations.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ansökan skickad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)) },
                new ActivityVM { Category = "Correspondence", Description = "Korrespondens angående ansökan", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FollowUpDate = null }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), Content = "Vi har fått svar på ansökan och ska följa upp." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Anna Svensson", Phone = "070-1234567", Email = "anna.svensson@techinnovations.se" },
                new ContactPersonVM { Name = "Erik Larsson", Phone = "070-7654321", Email = "erik.larsson@techinnovations.se" }
            }
            };
            companies.Add(company1);

            // Företag 2
            var company2 = new CompanyVM
            {
                Name = "Green Solutions AB",
                Url = "https://www.greensolutions.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Offer", Description = "Ansökan avvisad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FollowUpDate = null },
                new ActivityVM { Category = "Application", Description = "Skickade ny ansökan", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), Content = "Ansökan avvisades på grund av otillräckliga dokument." },
                new CommentVM { Label = "Kommentar 2", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), Content = "Ny ansökan skickad med kompletterande information." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Klara Holm", Phone = "070-2345678", Email = "klara.holm@greensolutions.se" }
            }
            };
            companies.Add(company2);

            // Företag 3
            var company3 = new CompanyVM
            {
                Name = "Blue Ocean Enterprises",
                Url = "https://www.blueocean.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Correspondence", Description = "Diskussion om nästa steg", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), Content = "Positiv respons på första förslaget." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Lena Karlsson", Phone = "070-3456789", Email = "lena.karlsson@blueocean.se" }
            }
            };
            companies.Add(company3);

            // Företag 4
            var company4 = new CompanyVM
            {
                Name = "SolarTech Solutions",
                Url = "https://www.solartech.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ansökan skickad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(6)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Content = "Ansökan skickades för att få finansiering till solcellsprojekt." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Martin Nilsson", Phone = "070-4567890", Email = "martin.nilsson@solartech.se" }
            }
            };
            companies.Add(company4);

            // Företag 5
            var company5 = new CompanyVM
            {
                Name = "Fintech Solutions",
                Url = "https://www.fintechsolutions.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Rejection", Description = "Avslag på ansökan", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), Content = "Avslag på grund av bristande dokumentation." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Johanna Olsson", Phone = "070-5678901", Email = "johanna.olsson@fintechsolutions.se" }
            }
            };
            companies.Add(company5);

            // Företag 6
            var company6 = new CompanyVM
            {
                Name = "HealthTech AB",
                Url = "https://www.healthtech.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ny ansökan inlämnad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), Content = "Ansökan skickad för att påbörja projekt." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Per Gustafsson", Phone = "070-6789012", Email = "per.gustafsson@healthtech.se" }
            }
            };
            companies.Add(company6);


            var company7 = new CompanyVM
            {
                Name = "Tech Innovations AB",
                Url = "https://www.techinnovations.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ansökan skickad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)) },
                new ActivityVM { Category = "Correspondence", Description = "Korrespondens angående ansökan", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FollowUpDate = null }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), Content = "Vi har fått svar på ansökan och ska följa upp." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Anna Svensson", Phone = "070-1234567", Email = "anna.svensson@techinnovations.se" },
                new ContactPersonVM { Name = "Erik Larsson", Phone = "070-7654321", Email = "erik.larsson@techinnovations.se" }
            }
            };
            companies.Add(company7);


            var company8 = new CompanyVM
            {
                Name = "Green Solutions AB",
                Url = "https://www.greensolutions.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Rejection", Description = "Ansökan avvisad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)) },
                new ActivityVM { Category = "Application", Description = "Skickade ny ansökan", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(10)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), Content = "Ansökan avvisades på grund av otillräckliga dokument." },
                new CommentVM { Label = "Kommentar 2", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), Content = "Ny ansökan skickad med kompletterande information." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Klara Holm", Phone = "070-2345678", Email = "klara.holm@greensolutions.se" }
            }
            };
            companies.Add(company8);


            var company9 = new CompanyVM
            {
                Name = "Blue Ocean Enterprises",
                Url = "https://www.blueocean.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Correspondence", Description = "Diskussion om nästa steg", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), Content = "Positiv respons på första förslaget." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Lena Karlsson", Phone = "070-3456789", Email = "lena.karlsson@blueocean.se" }
            }
            };
            companies.Add(company9);


            var company10 = new CompanyVM
            {
                Name = "SolarTech Solutions",
                Url = "https://www.solartech.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ansökan skickad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(6)) }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Content = "Ansökan skickades för att få finansiering till solcellsprojekt." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Martin Nilsson", Phone = "070-4567890", Email = "martin.nilsson@solartech.se" }
            }
            };
            companies.Add(company10);


            var company11 = new CompanyVM
            {
                Name = "Future Vision AB",
                Url = "https://www.futurevision.se",
                Activities = new ObservableCollection<ActivityVM>
            {
                new ActivityVM { Category = "Application", Description = "Ansökan skickad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FollowUpDate = DateOnly.FromDateTime(DateTime.Now.AddDays(8)) },
                new ActivityVM { Category = "Rejection", Description = "Ansökan avvisad", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FollowUpDate = null }
            },
                Comments = new ObservableCollection<CommentVM>
            {
                new CommentVM { Label = "Kommentar 1", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), Content = "Ansökan avvisades, vi kommer att förbättra dokumentationen." }
            },
                ContactPeople = new ObservableCollection<ContactPersonVM>
            {
                new ContactPersonVM { Name = "Oskar Andersson", Phone = "070-9876543", Email = "oskar.andersson@futurevision.se" },
                new ContactPersonVM { Name = "Sandra Lindström", Phone = "070-6781234", Email = "sandra.lindstrom@futurevision.se" }
            }
            };
            companies.Add(company11);

            return companies;
        }
    }
}


