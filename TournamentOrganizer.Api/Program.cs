
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TournamentOrganizer.Api;

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

        // logging
        builder.Host.UseSerilog(
            (ctx, logConfig) => logConfig.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
        );

        // Cors
        builder.Services.AddCors(
            options => 
            {
                options.AddPolicy("AllowAll", 
                    policyBuilder => policyBuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );
            }
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Cors
        app.UseCors("AllowAll");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
