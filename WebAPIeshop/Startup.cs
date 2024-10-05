namespace WebAPIeshop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

                options.AddPolicy(name: "AllowOrigin", builder =>
                {
                    builder.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod();

                });
            });

            services.AddControllers();

            services.AddSingleton<TokenService>();
            services.AddSingleton<OrderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }


}
