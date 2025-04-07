using Microsoft.AspNetCore.Authentication.Negotiate;
//using Microsoft.EntityFrameworkCore;
//using WorkShop.BL.Services.Implements;
//using WorkShop.BL.Services.Interfaces;
//using WorkShop.DAL.UnitOfWorks;
//using WorkShop.DAL;
//using WorkShop.DAL.Models;
using Microsoft.AspNetCore.Identity;
//using EMS.PL.Extensions;

namespace EMS.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddAuthentication(); AddCookie(IdentityConstants.ApplicationScheme);



            // Add services to the container.
            //builder.Services.AddDbContext<WorkShopDbContext>(
            // options => options.UseLazyLoadingProxies()
            // .UseSqlServer(builder.Configuration.GetConnectionString("con"))
            // );
            //builder.Services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<WorkShopDbContext>();
            ////.AddApiEndpoints();
            ////.AddDefaultTokenProviders();

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IService<Employee>, EmployeeService>();
            ////builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddControllers();//.AddNewtonsoftJson();

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGenJwtAuth();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddCustomJwtAuth(builder.Configuration);


            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });

            var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePages();
app.MapControllers();

app.Run();
        }
    }
}
