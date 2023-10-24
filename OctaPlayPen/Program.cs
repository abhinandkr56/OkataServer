using OctaPlayPen.Services;
using Okta.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var Configuration = builder.Configuration;
services.AddAuthorization();
services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
        options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
        options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
    })
    .AddOktaWebApi(new OktaWebApiOptions()
    {
        OktaDomain = Configuration["Okta:OktaDomain"],
        AuthorizationServerId = Configuration["Okta:AuthorizationServerId"],
        Audience = Configuration["Okta:Audience"],
    });
services.AddControllers();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});

services.AddSingleton<BookService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Add Swagger UI middleware
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();