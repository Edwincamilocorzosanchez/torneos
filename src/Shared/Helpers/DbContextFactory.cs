using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using torneos.src.Shared.Context;
using torneos.src.Shared.Helpers;
namespace torneos.Shared.Context.Helpers
{
    public class DbContextFactory
    {
        public static AppDbContext Create()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            string? connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")
                                ?? config.GetConnectionString("MySqlDB");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("No se encontro una cadena de conexion valida");

            var detectedVersion = MySqlVersionResolver.DetectVersion(connectionString);
            var minVersion = new Version(8, 0, 0);
            if (detectedVersion < minVersion)
                throw new InvalidOperationException($"Version de MySQL no soportada: {detectedVersion}. Requiere {minVersion} o superior.");
            Console.WriteLine($"🔍 Mysql detectado: {detectedVersion}");
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
                .Options;
            return new AppDbContext(options);
        }

    }
}