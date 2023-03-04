using HistoryEventBook.Model;
using HistoryEventBook.Model.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/ping", async (context) =>
{
    await context.Response.WriteAsync("pong");
}
);

app.MapGet("/event/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.HistoryEvents.ToListAsync();
});

app.MapPost("/event/add", async (HttpContext context, ApplicationDbContext db) =>
{
    HistoryEvent? historyEvent = await context.Request.ReadFromJsonAsync<HistoryEvent>();
    if (historyEvent != null)
    {
        db.HistoryEvents.Add(historyEvent);
        db.SaveChanges();
    }
    return historyEvent;
});

app.MapGet("/event/get/{id}", async (HttpContext context, ApplicationDbContext db, string id) =>
{
    HistoryEvent? historyEvent = db.HistoryEvents.FirstOrDefault(p => p.Id.ToString() == id);
    if (historyEvent == null) 
    {
        return Results.NotFound(new { message = "HistoryEvent не найден" });
    }

    return Results.Json(historyEvent);
});

app.MapGet("/person/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.People.ToListAsync();
});

app.MapPost("/person/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Person? person = await context.Request.ReadFromJsonAsync<Person>();
    if (person != null)
    {
        db.People.Add(person);
        db.SaveChanges();
    }
    return person;
});

app.MapGet("/person/get/{id}", async (HttpContext context, ApplicationDbContext db, string id) =>
{
    Person? person = await db.People.FirstOrDefaultAsync(p => p.Id.ToString() == id);
    if (person == null)
    {
        return Results.NotFound(new { message = "Person не найден" });
    }

    return Results.Json(person);
});

app.Run();