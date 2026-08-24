using AuthSysteamProject.DataAccessLayer;
using Sarthee.Services;
using Sarthee.Business;

var builder = WebApplication.CreateBuilder(args);


// ============================================================
// 1. REGISTER SERVICES
// ============================================================

// Add Controllers.
//
// This is required because we are building REST APIs
// that React will call.
builder.Services.AddControllers();


// Add MVC Controllers + Views.
//
// Since your frontend is React, you don't actually need
// MVC Views right now.
//
// We can remove this later if you're only using Web API.
// For now, I'm leaving it because your existing project
// may already depend on it.
builder.Services.AddControllersWithViews();


// ============================================================
// 2. DEPENDENCY INJECTION
// ============================================================

// Register Authentication Data Access Layer.
//
// AddScoped means:
//
// One IAuthDL / AuthDL instance is created
// for each HTTP request.
//
// Example:
//
// React Request
//      ↓
// AuthController
//      ↓
// IAuthDL
//      ↓
// AuthDL
//
// When the request finishes, the scoped object
// is disposed.
builder.Services.AddScoped<IAuthDL, AuthDL>();


// Register Interview Service.
//
// IInterviewService = interface
// InterviewService = actual implementation
//
// This tells ASP.NET Core:
//
// "Whenever a controller asks for IInterviewService,
// give it an InterviewService."
//
// We use Scoped because this service will eventually
// work with Entity Framework's DbContext, which is
// normally registered as Scoped as well.
builder.Services.AddScoped<IInterviewService, InterviewService>();


// ============================================================
// 3. OPENAPI
// ============================================================

// Add OpenAPI services.
//
// This must be registered BEFORE builder.Build().
builder.Services.AddOpenApi();


// ============================================================
// 4. CORS
// ============================================================

// React and .NET will normally run on different ports.
//
// Example:
//
// React:
// http://localhost:5173
//
// .NET:
// https://localhost:7000
//
// Because they are different origins, the browser can
// block the React → .NET API request.
//
// CORS allows React to communicate with our API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        // For development, allow requests from any origin.
        //
        // Later, when we deploy the application,
        // we should restrict this to our actual React URL.
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// ============================================================
// 5. BUILD THE APPLICATION
// ============================================================

// IMPORTANT:
//
// All builder.Services.Add... registrations must happen
// BEFORE this line.
var app = builder.Build();


// ============================================================
// 6. DEVELOPMENT CONFIGURATION
// ============================================================

if (app.Environment.IsDevelopment())
{
    // Creates the OpenAPI JSON endpoint.
    //
    // We can use this to inspect/test our APIs.
    app.MapOpenApi();
}


// Print message when application starts.
Console.WriteLine("Hello Mayuri");


// Print API URLs when application starts.
app.Lifetime.ApplicationStarted.Register(() =>
{
    foreach (var address in app.Urls)
    {
        Console.WriteLine($"API running at: {address}");
    }
});


// ============================================================
// 7. HTTP REQUEST PIPELINE
// ============================================================

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();


// Enable the CORS policy we created above.
//
// This allows our React application to call
// the ASP.NET Core API.
app.UseCors("ReactPolicy");


// Enable authorization middleware.
app.UseAuthorization();


// Map our API controllers.
//
// Example:
//
// /api/auth/login
// /api/interview/questions
app.MapControllers();


// Start the application.
app.Run();