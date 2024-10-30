using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ScheduleDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Инициализация базы данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ScheduleDbContext>();
        context.Database.EnsureCreated();
        
        // Проверяем, есть ли данные
        if (!context.ClassPeriods.Any())
        {
            // Добавляем периоды занятий
            context.ClassPeriods.AddRange(
                new ClassPeriod { Id = 1, Time = "8:30 - 10:05" },
                new ClassPeriod { Id = 2, Time = "10:25 - 12:00" },
                new ClassPeriod { Id = 3, Time = "12:20 - 13:55" },
                new ClassPeriod { Id = 4, Time = "14:15 - 15:50" }
            );
        }

        if (!context.Classrooms.Any())
        {
            // Добавляем аудитории
            context.Classrooms.AddRange(
                new Classroom { Id = 1, Number = "101", Capacity = 30 },
                new Classroom { Id = 2, Number = "102", Capacity = 25 },
                new Classroom { Id = 3, Number = "201", Capacity = 40 },
                new Classroom { Id = 4, Number = "202", Capacity = 35 }
            );
        }

        if (!context.Groups.Any())
        {
            // Добавляем группы
            context.Groups.AddRange(
                new Group { Id = 1, Name = "КН-11", Year = 1, NumberOfStudents = 25 },
                new Group { Id = 2, Name = "КН-12", Year = 1, NumberOfStudents = 27 },
                new Group { Id = 3, Name = "КН-21", Year = 2, NumberOfStudents = 23 },
                new Group { Id = 4, Name = "КН-22", Year = 2, NumberOfStudents = 24 }
            );
        }

        if (!context.Instructors.Any())
        {
            // Добавляем преподавателей
            context.Instructors.AddRange(
                new Instructor { Id = 1, Name = "Іванов І.І.", Department = "Кафедра КН", Email = "ivanov@example.com" },
                new Instructor { Id = 2, Name = "Петров П.П.", Department = "Кафедра КН", Email = "petrov@example.com" },
                new Instructor { Id = 3, Name = "Сидоров С.С.", Department = "Кафедра КН", Email = "sidorov@example.com" },
                new Instructor { Id = 4, Name = "Коваль К.К.", Department = "Кафедра КН", Email = "koval@example.com" }
            );
        }

        if (!context.Schedules.Any())
        {
            // Добавляем расписание
            context.Schedules.AddRange(
                new Schedule 
                { 
                    Id = 1, 
                    GroupId = 1, 
                    InstructorId = 1, 
                    ClassroomId = 1, 
                    ClassPeriodId = 1 
                },
                new Schedule 
                { 
                    Id = 2, 
                    GroupId = 2, 
                    InstructorId = 2, 
                    ClassroomId = 2, 
                    ClassPeriodId = 2 
                }
            );
        }

        context.SaveChanges();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();