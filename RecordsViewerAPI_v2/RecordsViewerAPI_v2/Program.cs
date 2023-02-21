using Microsoft.EntityFrameworkCore;
using RecordsViewerAPI_v2.Models;
using RecordsViewerAPI_v2.Services;

namespace RecordsViewerAPI_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var provider = builder.Services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContext<RecordsViewerContext>(opts => opts.UseSqlServer(configuration["ConnectionString:RecordsViewerDB"]));
            builder.Services.AddScoped<IRecordsService, RecordsService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}