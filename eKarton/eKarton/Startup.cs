using eKarton.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using eKarton.Services;
using eKarton.Models.SQL;

namespace eKarton
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
            services.AddCors();
            services.AddControllers();

            services.Configure<VisitArchiveDatabaseSettings>(
                Configuration.GetSection(nameof(VisitArchiveDatabaseSettings)));

            services.AddDbContext<MedicalRecordContext>(opts => opts.UseSqlServer(Configuration["SQLConnection:ConnectionString"]));

            services.AddSingleton<IVisitArchiveDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<VisitArchiveDatabaseSettings>>().Value);

            services.AddSingleton<AllergyService>();
            services.AddSingleton<AnamnesisService>();
            services.AddSingleton<DiseaseService>();
            services.AddSingleton<DoctorService>();
            services.AddSingleton<ImageService>();
            services.AddSingleton<MedicalRecordService>();
            services.AddSingleton<MedicineService>();
            services.AddSingleton<PatientService>();
            services.AddSingleton<VaccinationStatusService>();
            services.AddSingleton<VaccineService>();
            services.AddSingleton<VisitService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
