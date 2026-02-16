using Microsoft.Extensions.Options;
using SurveyApi.Context;
using SurveyApi.Model;
using SurveyApi.Repositories;
using SurveyApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SurveyContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("InvitroCapitalSQL")));




builder.Services.AddScoped<IRepository<MultipleResponses>, Repository<MultipleResponses>>();
builder.Services.AddScoped<IRepository<OptionsSurvey>, Repository<OptionsSurvey>>();
builder.Services.AddScoped<IRepository<Question>, Repository<Question>>();
builder.Services.AddScoped<IRepository<Responses>, Repository<Responses>>();
builder.Services.AddScoped<IRepository<Survey>, Repository<Survey>>();
builder.Services.AddScoped<IRepository<UserSurvey>, Repository<UserSurvey>>();

builder.Services.AddScoped<IServiceMultipleResponses, ServiceMultipleResponses>();
builder.Services.AddScoped<IServiceOptions, ServiceOptions>();
builder.Services.AddScoped<IServiceQuestion, ServiceQuestion>();
builder.Services.AddScoped<IServiceResponses, ServiceResponses>();
builder.Services.AddScoped<IServiceSurvey, ServiceSurvey>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped<IServiceManageSurvey, ServiceManageSurvey>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   app.UseSwagger();
    app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger salga en la raíz (sin /swagger)
});
//}

app.UseHttpsRedirection();
app.UseStaticFiles(); // <--- OBLIGATORIO para cargar los archivos de la UI
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
