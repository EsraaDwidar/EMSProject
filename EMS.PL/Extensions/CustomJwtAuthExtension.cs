//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.Design;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;


//namespace EMS.PL.Extensions
//{
//    public static class CustomJwtAuthExtension
//    {
//        public static void AddCustomJwtAuth(this IServiceCollection service, ConfigurationManager configuration)
//        {
//            service.AddAuthentication(o =>
//            {
//                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(o =>
//            {
//                o.RequireHttpsMetadata = false;
//                o.SaveToken = true;
//                o.TokenValidationParameters = new TokenValidationParameters()
//                {
//                    ValidateIssuer = true,
//                    ValidIssuer = configuration["JWT:Issuer"],
//                    ValidateAudience = false,
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
//                };
//            });
//        }

//        public static void AddSwaggerGenJwtAuth(this IServiceCollection services)
//        {
//            services.AddSwaggerGen(o =>
//            {
//                o.SwaggerDoc("v1", new OpenApiInfo()
//                {
//                    Version = "v1",
//                    Title = "test api",
//                    Description = "adasdsad",
//                    Contact = new OpenApiContact()
//                    {
//                        Name = "al Mohamady",
//                        Email = "ahmed@gmail.com",
//                        Url = new Uri("https://mydomain.com")
//                    }
//                });

//                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = "Bearer",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Description = "Enter the JWT Key"
//                });

//                o.AddSecurityRequirement(new OpenApiSecurityRequirement() {
//                    {
//                       new OpenApiSecurityScheme()
//                       {
//                          Reference = new OpenApiReference()
//                          {
//                             Type = ReferenceType.SecurityScheme,
//                             Id = "Bearer"
//                          },
//                          Name = "Bearer",
//                          In = ParameterLocation.Header
//                       },
//                       new List<string>()
//                    }
//                });
//            });
//        }
//    }
//            //        service.AddAuthentication(x =>
//            //        {
//            //            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            //            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            //            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            //        }).AddJwtBearer(o =>
//            //        {
//            //            o.RequireHttpsMetadata = false;
//            //            o.SaveToken = true;
//            //            o.TokenValidationParameters = new TokenValidationParameters()
//            //            {
//            //                ValidateIssuer = true,
//            //                ValidIssuer = configuration["JWT:Issuer"],
//            //                ValidateAudience = false,
//            //                ValidateIssuerSigningKey = true,
//            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
//            //            };
//            //        });
//            //    }
//            //    public static void AddSwaggerGenJWTAuth(this IServiceCollection service)
//            //    {
//            //        service.AddSwaggerGen(x =>
//            //        {
//            //            x.SwaggerDoc("v1", new OpenApiInfo()
//            //            {
//            //                Version = "v1",
//            //                Title = "test API",
//            //                Description = "AuthApp",
//            //                Contact = new OpenApiContact()
//            //                {
//            //                    Name = "Esraa Dwidar",
//            //                    Email = "esraadwidar770@gmail.com"
//            //                }
//            //            });
//            //            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//            //            {
//            //                Name = "Authorization",
//            //                Type = SecuritySchemeType.ApiKey,
//            //                Scheme = "Bearer",
//            //                BearerFormat = "JWT",
//            //                In = ParameterLocation.Header,
//            //                Description = "Enter the JWT Key: "
//            //            });
//            //            x.AddSecurityRequirement(new OpenApiSecurityRequirement() {
//            //            {
//            //                new OpenApiSecurityScheme()
//            //                {
//            //                    Reference = new OpenApiReference()
//            //                    {
//            //                        Type = ReferenceType.SecurityScheme,
//            //                        Id = "Bearer"
//            //                    },
//            //                    Name = "Bearer",
//            //                    In = ParameterLocation.Header
//            //                },
//            //                new List<string>()
//            //                }
//            //            });
//            //        });
//            //    }
//            //}
//            //{
//            //    public static void AddCustomJwtAuth(this IServiceCollection service, ConfigurationManager configuration)
//            //    {
//            //        service.AddAuthentication(x =>
//            //        {
//            //            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            //            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            //            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            //        }).AddJwtBearer(o =>
//            //        {
//            //            o.RequireHttpsMetadata = false;
//            //            o.SaveToken = true;
//            //            o.TokenValidationParameters = new TokenValidationParameters()
//            //            {
//            //                ValidateIssuer = true,
//            //                ValidIssuer = configuration["JWT:Issuer"],
//            //                ValidateAudience = false,
//            //                ValidateIssuerSigningKey = true,
//            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
//            //            };
//            //        });
//            //    }
//            //    public static void AddSwaggerGenJWTAuth(this IServiceCollection service)
//            //    {
//            //        service.AddSwaggerGen(x =>
//            //        {
//            //            x.SwaggerDoc("v1", new OpenApiInfo()
//            //            {
//            //                Version = "v1",
//            //                Title = "test API",
//            //                Description = "AuthApp",
//            //                Contact = new OpenApiContact()
//            //                {
//            //                    Name = "Esraa",
//            //                    Email = "esraadwidar770@gmail.com"
//            //                }
//            //            });
//            //            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//            //            {
//            //                Name = "Authorization",
//            //                Type = SecuritySchemeType.ApiKey,
//            //                Scheme = "Bearer",
//            //                BearerFormat = "JWT",
//            //                In = ParameterLocation.Header,
//            //                Description = "Enter the JWT Key: "
//            //            });
//            //            x.AddSecurityRequirement(new OpenApiSecurityRequirement() {
//            //            {
//            //                new OpenApiSecurityScheme()
//            //                {
//            //                    Reference = new OpenApiReference()
//            //                    {
//            //                        Type = ReferenceType.SecurityScheme,
//            //                        Id = "Bearer"
//            //                    },
//            //                    Name = "Bearer",
//            //                    In = ParameterLocation.Header
//            //                },
//            //                new List<string>()
//            //                }
//            //            });
//            //        });
//            //    }
//            //}
//        }
