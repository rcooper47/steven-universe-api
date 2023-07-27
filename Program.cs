using steven_api.Data;
using steven_api.Services;
using Microsoft.EntityFrameworkCore;
using steven_api.Wrappers;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//builder.Services.Add(new ServiceDescriptor(typeof(CharacterDbContext), new CharacterDbContext(builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.Add(new ServiceDescriptor(typeof(CharacterDbContext), new CharacterDbContext(Environment.GetEnvironmentVariable("Railway"))));


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService> (o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());

    return new UriService(uri);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("*");
                      });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();
// app.UseExceptionHandler(
//     options =>
//     {
//         options.Run(async context =>
//         {
//             context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//             context.Response.ContentType = "text/html";
//             var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
//             if (null != exceptionObject)
//             {
//                 var errorMessage = $"{exceptionObject.Error.Message}";
//                 await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
//             }
//         });
//     }
// );

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {}
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
