namespace SignalRHubSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //signalr
            services.AddSignalR(options => options.EnableDetailedErrors = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();

            app
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapHub<UploadHub>("/upload"));
        }
    }
}
