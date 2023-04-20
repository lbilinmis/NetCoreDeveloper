using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//RateLimit i�in gerekli sevisler
builder.Services.AddOptions();

builder.Services.AddMemoryCache();

builder.Services.AddInMemoryRateLimiting();

builder.Services.Configure<IpRateLimitPolicies>(options =>
{
    options.IpRules = new List<IpRateLimitPolicy>
    {
        new IpRateLimitPolicy
        {
            Ip = "127.0.0.1",
            Rules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                     //Endpoint = "*", // T�m endpoint ler i�in 
                Endpoint = "*",
                Period = "10s", // s�re sn dk saat gun �eklinde
                Limit = 10
                }
            }
        }
    };
});

builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = false;
    options.HttpStatusCode = 429;
    //options.IpWhitelist = new List<string> { "127.0.0.1", "::1" };
    options.IpWhitelist = new List<string> { "127.0.0.1" };
    options.RealIpHeader = "X-Real-IP"; // load balancer i�lemi i�in kullan�l�r
    options.EndpointWhitelist= new List<string>(){ "put:/api/product" };
    options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                //Endpoint = "*", // T�m endpoint ler i�in 
                Endpoint = "*:/api/product",
                Period = "10s", // s�re sn dk saat gun �eklinde
                Limit = 2
            },
             new RateLimitRule
            {
                //Endpoint = "*", // T�m endpoint ler i�in 
                Endpoint = "*:/api/product",

                Period = "1h", // bir saat
                Limit = 5
            },
             new RateLimitRule
            {
                //Endpoint = "*", // T�m endpoint ler i�in 
                Endpoint = "*:/api/categories",

                Period = "10s", // bir g�n
                Limit = 5
            }

        };
});



builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();



var app = builder.Build();
app.UseIpRateLimiting(); // ekleme i�lemi yapld�



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
