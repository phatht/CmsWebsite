using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Formatting.Compact;

namespace CommonNetCore.Serilog
{

    public static class Extensions
    {
        public static async Task WithSeriLog(Func<ValueTask> func)
        {
            Log.Logger = new LoggerConfiguration()
                //.WriteTo.Console()
                .WriteTo.File(new RenderedCompactJsonFormatter(), "/Serilog/log_" + DateTime.Now.ToString("dd-mm-yyyy") + ".json")
                //.WriteTo.Seq(Environment.GetEnvironmentVariable("urlSeq") ?? "http://localhost:5341/") 
                .CreateBootstrapLogger();

            try
            {
                await func.Invoke();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }
        }

        public static void AddSerilog(this ConfigureHostBuilder hostBuilder, string appName)
        {
            if (hostBuilder is null)
            {
                throw new ArgumentNullException(nameof(hostBuilder));
            }

            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException($"'{nameof(appName)}' cannot be null or empty.", nameof(appName));
            }

            hostBuilder.UseSerilog((ctx, lc) => lc
                .WriteTo.File(new RenderedCompactJsonFormatter(), "/Serilog/log_" + DateTime.Now.ToString("dd-mm-yyyy") + ".json")
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", appName)
                .ReadFrom.Configuration(ctx.Configuration));
        }
    }
}
