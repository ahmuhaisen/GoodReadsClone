using GoodReadersClone.Api.Mapper;
using GoodReadersClone.Api;
using GoodReadersClone.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.RegisterIdentity();

builder.Services.RegisterApplicationDbContext(builder.Configuration);

builder.Services.RegisterDomainServices();

builder.Services.RegisterMediatR();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.RegisterOptions(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MaintenanceMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();