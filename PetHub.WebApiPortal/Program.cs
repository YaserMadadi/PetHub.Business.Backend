
using System.Threading.RateLimiting;

namespace PetHub.WebApiPortal
{
    public class Program
    {
		public static string NardPolicyName { get; set; } = "NardCorsPolicy";

		public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(NardPolicyName, policy =>
				{
					policy
						.WithOrigins("http://localhost:4200") // Your Angular dev server or production domain
															  //.AllowAnyOrigin()
						.AllowAnyHeader()
						//.AllowCredentials()
						.AllowAnyMethod();
				});
			});

			builder.Services.AddRateLimiter(options =>
			{
				options.AddPolicy("VerificationPolicy", context =>
				{
					// Use the client's IP as the partition key
					var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

					return RateLimitPartition.GetFixedWindowLimiter(
						partitionKey: ip,
						factory: partition => new FixedWindowRateLimiterOptions
						{
							PermitLimit = 5,                // max 5 requests
							Window = TimeSpan.FromMinutes(1), // per 1 minute
							QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
							QueueLimit = 0
						});
				});
			});

			// Add services to the container.

			builder.Services.AddControllers();

            PetHub.Services.ServiceProvider.Load(builder.Services);

            EssentialCore.DataAccess.ConnectionManager.Init(builder.Configuration);

			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
			app.UseCors(NardPolicyName);


			app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
