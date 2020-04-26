using eKarton.Models;
using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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

            services.AddScoped<IService<Allergy>, AllergyService>();
            services.AddScoped<IService<Anamnesis>, AnamnesisService>();
            services.AddScoped<IService<Disease>, DiseaseService>();
            services.AddScoped<IService<Doctor>, DoctorService>();
            services.AddScoped<IService<Snapshot>, SnapshotService>();
            services.AddScoped<IService<Instruction>, InstructionService>();
            services.AddScoped<IService<Analysis>, AnalysisService>();
            services.AddScoped<IService<MedicalRecord>, MedicalRecordService>();
            services.AddScoped<IService<Medicine>, MedicineService>();
            services.AddScoped<IService<Patient>, PatientService>();
            services.AddScoped<IService<VaccinationStatus>, VaccinationStatusService>();
            services.AddScoped<IService<Vaccine>, VaccineService>();
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
