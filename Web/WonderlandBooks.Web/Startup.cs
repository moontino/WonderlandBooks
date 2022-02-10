namespace WonderlandBooks.Web
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using WonderlandBooks.Data;
    using WonderlandBooks.Data.Common;
    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Data.Repositories;
    using WonderlandBooks.Data.Seeding;
    using WonderlandBooks.Services;
    using WonderlandBooks.Services.Data;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Services.Data.ModelDataServices;
    using WonderlandBooks.Services.Mapping;
    using WonderlandBooks.Services.Messaging;
    using WonderlandBooks.Web.ViewModels;
    using WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WonderlandDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<WonderlandDbContext>();
            services.AddAutoMapper(typeof(Startup));
            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IGoodreadsScraperService, GoodreadsScraperService>();
            services.AddTransient<IGoodreadsDataService, GoodreadsDataService>();

            services.AddScoped<IBookRecommendationsService, BookRecommendationsService>();

            services.AddTransient<IAuthorsService, AuthorsService>();
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<ICountDataService, CountDataService>();
            services.AddTransient<IStoriesService, StoriesService>();
            services.AddTransient<IChapterService, ChapterService>();

            services.AddTransient<IModifiedStoryService, ModifiedStoryService>();
            services.AddTransient<IModifiedChapterService, ModifiedChapterService>();
            services.AddTransient<ICreateLibraryService, CreateLibraryService>();

            services.AddTransient<IEditionLanguageInputModelListItems, EditionLanguageInputModelListItems>();
            services.AddTransient<IGenreInputModelListItems, GenreInputModelListItems>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<WonderlandDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
