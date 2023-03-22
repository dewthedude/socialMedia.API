using CustomForms.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

using SocialMedia.Repository.EF.Context;
using SocialMedia.Repository.Interfaces;
using SocialMedia.Repository.Repositories;
using SocialMedia.Repository.Repository;
using SocialMedia.Service.Services.Master;
using SocialMedia.Service.Services.Package;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


try
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
    });


    builder.Services.AddCors(o =>
    {
        o.AddPolicy(
            "MyPolicy",
            builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
    });
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    builder.Configuration.AddEnvironmentVariables();
    builder.Services.AddScoped<IPackageService, PackageService>();
    builder.Services.AddScoped<IMasterCategoryRepository, MasterCategoryRepository>();
    builder.Services.AddScoped<IMasterSubCategoryRepository, MasterSubCategoryRepository>();
    builder.Services.AddScoped<IMasterFeatureRepository, MasterFeatureRepository>();
    builder.Services.AddScoped<IMasterService, MasterService>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


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
    app.UseCors("MyPolicy");
    app.Run();
}
catch (Exception ex)
{

}
