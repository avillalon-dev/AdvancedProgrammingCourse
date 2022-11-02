using Model;
using Repository;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add repository as service
            var connectionString = new ConnectionString(@"Data Source=ADRIANA-PC\SQLEXPRESS;AttachDBFilename=D:\cujae\Programación Avanzada\Código\DB\HumanResourcesDB.mdf;Initial Catalog=HumanResourcesDB;User ID=sa;Password=qwerty");
            builder.Services.AddSingleton(connectionString);
            builder.Services.AddScoped<IWorkerRepository, DBRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}