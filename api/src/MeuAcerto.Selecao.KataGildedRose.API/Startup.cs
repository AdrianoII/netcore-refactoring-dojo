using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;
using MeuAcerto.Selecao.KataGildedRose.Application.Services;
using MeuAcerto.Selecao.KataGildedRose.Domain.Interfaces.UseCases;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using MeuAcerto.Selecao.KataGildedRose.Domain.Validators;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.ConnectionHandlers;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.UnityOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace MeuAcerto.Selecao.KataGildedRose.API
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
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAtualizarItemQualidadeUseCase, AtualizarItemQualidadeUseCase>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IDbConnectionHandler, PostgresConnectionHandler>();
            services.AddScoped<IDbConnection>(
                (sp) => new NpgsqlConnection(Configuration.GetConnectionString("gildedrosedb"))
            );
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IEstoqueService, EstoqueService>();


            services.AddControllers()
                .AddFluentValidation(
                    fv => fv.RegisterValidatorsFromAssemblyContaining<ItemValidator>()
                )
                .AddJsonOptions(opts => { opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins(Configuration["urlApp"])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    );
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "MeuAcerto.Selecao.KataGildedRose.API", Version = "v1",
                        Description = "Uma API desenvolvida para o teste prático da Meu Acerto",
                        Contact = new OpenApiContact
                        {
                            Name = "Adriano Corbelino II",
                            Email = "adrianocorbelinoii@gmail.com",
                            Url = new Uri("https://github.com/AdrianoII"),
                        },
                    });

                List<string> xmlFiles = Directory
                    .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase("/api/");

            if (env.IsDevelopment() || env.EnvironmentName == "Docker")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeuAcerto.Selecao.KataGildedRose.API v1"));
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}