using ContractDemo.Features;
using ContractDemo.Features.LeadScoring;
using ContractDemo.Integrations;
using ContractDemo.Integrations.Leads;
using Kentico.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);
var isKenticoEnabled = builder.Configuration.GetValue<bool>("Kentico:Enabled");

// Add services to the container.
if (isKenticoEnabled)
{
    builder.Services.AddKentico(features =>
    {
        // Optional Kentico features are enabled with additional packages as needed.
    });

    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();
}

builder.Services.AddAuthentication();
builder.Services.AddServerSideBlazor();
builder.Services.AddHealthChecks();
builder.Services.AddFeatureServices();
builder.Services.AddIntegrationServices();
builder.Services.AddHttpClient();

var app = builder.Build();
if (isKenticoEnabled)
{
    app.InitKentico();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();

if (isKenticoEnabled)
{
    app.UseKentico();
}

app.UseAuthorization();

if (isKenticoEnabled)
{
    app.MapControllers();
}
else
{
        app.MapGet("/", () => Results.Content(
                """
                <!doctype html>
                <html lang="en">
                <head>
                    <meta charset="utf-8" />
                    <meta name="viewport" content="width=device-width, initial-scale=1" />
                    <title>ContractDemo - Demo Mode</title>
                    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
                </head>
                <body class="bg-light">
                    <main class="container py-5">
                        <div class="p-4 bg-white border rounded shadow-sm">
                            <h1 class="h3 mb-3">ContractDemo - Demo Mode</h1>
                            <p class="text-muted mb-4">Xperience by Kentico starter with non-Kentico fallback for local development and contract demos.</p>
                            <ul class="list-group">
                                <li class="list-group-item"><strong>POST</strong> /api/leads/score</li>
                                <li class="list-group-item"><strong>POST</strong> /api/leads/submit</li>
                                <li class="list-group-item"><strong>GET</strong> /health/ready</li>
                            </ul>
                        </div>
                    </main>
                </body>
                </html>
                """,
                "text/html"));

    app.MapPost("/api/leads/score", (LeadScoreRequest request, ILeadScoringService scoringService) =>
    {
        var result = scoringService.Score(request);
        return Results.Ok(result);
    });

    app.MapPost("/api/leads/submit", async (LeadSubmission submission, ILeadSubmissionClient leadSubmissionClient, CancellationToken cancellationToken) =>
    {
        if (!submission.AcceptedConsent)
        {
            return Results.BadRequest(new { message = "Consent is required." });
        }

        var reference = await leadSubmissionClient.SubmitAsync(submission, cancellationToken);
        return Results.Ok(new { message = "Lead submitted.", reference });
    });
}

app.MapBlazorHub();
app.MapHealthChecks("/health/ready");

if (isKenticoEnabled)
{
    app.MapRazorPages();
    app.Kentico().MapRoutes();
}

app.Run();

public partial class Program;
