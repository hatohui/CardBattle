namespace Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseAccountServicePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = "Account Service API Docs";
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Account Service API v1");

            if (app.Environment.IsDevelopment())
            {
                options.RoutePrefix = "";
            }
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/healthz");

        return app;
    }
}
