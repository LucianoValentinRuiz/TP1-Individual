using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Service;
using Infrastructure.Command;
using Infrastructure.Data;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//Data base
var conectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<CRMContext>(options => options.UseSqlServer(conectionString));

//custom
builder.Services.AddTransient<ICampaignTypesService, CampaignTypesService>();
builder.Services.AddTransient<ICampaignTypesQuery,CampaignTypesQuery>();

builder.Services.AddTransient<IClientService,ClientsService>();
builder.Services.AddTransient<IClientsQuery,ClientsQuery>();
builder.Services.AddTransient<IClientsCommand,ClientsCommand>();

builder.Services.AddTransient<IInteractionTypesService, InteractionTypesService>();
builder.Services.AddTransient<IInteractionTypesQuery, InteractionTypesQuery>();

builder.Services.AddTransient<ITaskStatusService, TaskStatusService>();
builder.Services.AddTransient<ITaskStatusQuery, TaskStatusQuery>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsersQuery, UsersQuery>();

builder.Services.AddTransient<IInteractionsService, InteractionsService>();
builder.Services.AddTransient<IInteractionsCommand, InteractionsCommand>();
builder.Services.AddTransient<IInteractionsQuery, InteractionsQuery>();

builder.Services.AddTransient<ITasksService, TasksService>();
builder.Services.AddTransient<ITasksCommand, TaskCommand>();
builder.Services.AddTransient<ITasksQuery, TasksQuery>();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IProjectsCommand, ProjectCommand>();
builder.Services.AddTransient<IProjectsQuery, ProjectsQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
