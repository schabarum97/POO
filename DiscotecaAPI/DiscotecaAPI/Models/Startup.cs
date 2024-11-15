using Microsoft.EntityFrameworkCore;
using DiscotecaAPI.Data;

namespace DiscotecaAPI
{
    // Configurações iniciais da aplicação
    public class Startup
    {
        // Configura os serviços necessários para o funcionamento da aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do banco de dados em memória para armazenamento temporário
            services.AddDbContext<InMemoryDbContext>(options =>
                options.UseInMemoryDatabase("DiscotecaDb"));

            // Configuração para suporte a controladores da API
            services.AddControllers();

            // Configuração do Swagger para documentação da API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Discoteca API",
                    Version = "v1"
                });
            });
        }

        // Configura os middlewares da aplicação
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middleware para tratamento de erros no ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware para configuração das rotas
            app.UseRouting();

            // Middleware para inicializar o Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discoteca API V1");
                c.RoutePrefix = string.Empty; // Deixa o Swagger acessível na raiz do projeto
            });

            // Mapeamento dos endpoints dos controladores
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
