using AutoMapper;
using BAL.Implementation.Services;
using BAL.Interfaces;
using BAL.Mapper;
using DAL;
using DAL.Implementation;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IQuoteService, QuoteService>();
            services.AddTransient<IAuthorsService, AuthorsService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
