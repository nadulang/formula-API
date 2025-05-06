using formula_API.Data;
using formula_API.Interface;
using formula_API.Models;
using formula_API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var env = builder.Environment.EnvironmentName;
    Console.WriteLine($"Active Environment: {env}");

    if (env == "Development")
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

builder.Services.AddScoped<IFormulaRepository, FormulaRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Formulas.Any())
    {
        db.Formulas.Add(new Formula
        {
            FormulaId = 1,
            ProductId = 1,
            Title = "Formulasi Jamu Obat Batuk",
            StepsData = "{\n    \"steps\": [\n      {\n        \"stepTitle\": \"Potong semua bahan\",\n        \"parameters\": {\n          \"deskripsi\": \"Memotong bahan-bahan utama menjadi bagian kecil agar mudah direbus.\",\n          \"durasi\": 5,\n          \"suhu\": 27.0,\n          \"tekanan\": 1.0\n        },\n        \"sub_steps\": [\n          {\n            \"subStepTitle\": \"Potong kunyit\",\n            \"sub_steps\": [\n              {\n                \"subStepTitle\": \"Gunakan pisau steril\"\n              }\n            ]\n          },\n          {\n            \"subStepTitle\": \"Potong kencur\"\n          },\n          {\n            \"subStepTitle\": \"Potong temulawak\"\n          }\n        ]\n      },\n      {\n        \"stepTitle\": \"Rebus dengan air hingga mendidih\",\n        \"parameters\": {\n          \"deskripsi\": \"Campur semua bahan dengan 200 ml air dan rebus hingga mendidih. Matikan api setelah mendidih.\",\n          \"durasi\": 7,\n          \"suhu\": 100.0,\n          \"tekanan\": 1.0\n        }\n      }\n    ]\n  }",
            CreatedDate = new DateTime(2025, 5, 4, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "API"
        });
        db.Formulas.Add(new Formula
        {
            FormulaId = 2,
            ProductId = 2,
            Title = "Formulasi Jamu Nyeri Haid",
            StepsData = "{\n    \"steps\": [\n      {\n        \"stepTitle\": \"Siapkan kunyit dan asam jawa\",\n        \"parameters\": {\n          \"deskripsi\": \"Iris kunyit dan siapkan asam jawa di dalam gelas.\",\n          \"durasi\": 3,\n          \"suhu\": 27.0,\n          \"tekanan\": 1.0\n        },\n        \"sub_steps\": [\n          {\n            \"subStepTitle\": \"Iris 2 ruas kunyit\",\n            \"parameters\": {\n              \"deskripsi\": \"Kunyit diiris tipis-tipis untuk memaksimalkan ekstraksi.\",\n              \"durasi\": 1,\n              \"suhu\": 27.0,\n              \"tekanan\": 1.0\n            },\n            \"sub_steps\": [\n              {\n                \"subStepTitle\": \"Gunakan talenan bersih\",\n                \"parameters\": {\n                  \"deskripsi\": \"Pastikan talenan bebas dari bekas potongan lain.\",\n                  \"durasi\": 0,\n                  \"suhu\": 27.0,\n                  \"tekanan\": 1.0\n                }\n              }\n            ]\n          },\n          {\n            \"subStepTitle\": \"Masukkan 1 sdt asam jawa\",\n            \"parameters\": {\n              \"deskripsi\": \"Asam jawa dilarutkan sebagian dalam air untuk menambah rasa asam.\",\n              \"durasi\": 1,\n              \"suhu\": 27.0,\n              \"tekanan\": 1.0\n            }\n          }\n        ]\n      },\n      {\n        \"stepTitle\": \"Tambahkan jeruk nipis\",\n        \"parameters\": {\n          \"deskripsi\": \"Masukkan irisan jeruk nipis untuk menambah rasa segar.\",\n          \"durasi\": 1,\n          \"suhu\": 40.0,\n          \"tekanan\": 1.0\n        }\n      }\n    ]\n  }",
            CreatedDate = new DateTime(2025, 5, 4, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "API"
        });
        db.SaveChanges();
    }
};

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
