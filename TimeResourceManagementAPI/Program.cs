
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TimeResourceManagementAPI.Contracts.User;

namespace TimeResourceManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Эффективное распределение времени и ресурсами.",
                    Description = "Это API предназначено для оптимизации планирования и распределения рабочих часов, материальных и человеческих ресурсов в проектах и бизнес-процессах.\r\n\r\n",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Настройка Mapster
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            // Настройка маппинга User
            TypeAdapterConfig<User, UserResponse>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.DepartmentId, src => src.DepartmentId)
                .IgnoreNonMapped(true);

            TypeAdapterConfig<CreateUserRequest, User>
                .NewConfig()
                .Map(dest => dest.UserId, src => 0)
                .Map(dest => dest.DepartmentId, src => src.DepartmentId)
                .IgnoreNonMapped(true);

            TypeAdapterConfig<UpdateUserRequest, User>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.DepartmentId, src => src.DepartmentId)
                .IgnoreNonMapped(true);

            // Игнорировать навигационные свойства при маппинге
            TypeAdapterConfig.GlobalSettings.Default.IgnoreMember((member, side) =>
                member.Name.Contains("Department") ||
                member.Name.Contains("Tasks") ||
                member.Name.Contains("Projects"));


            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                "Server=DESKTOP-63756UI;Database=time_management;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

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