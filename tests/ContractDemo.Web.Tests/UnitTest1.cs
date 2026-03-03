using ContractDemo.Features.LeadScoring;
using ContractDemo.Integrations.Leads;

namespace ContractDemo.Web.Tests;

public class ServiceTests
{
    [Fact]
    public void LeadScoring_ReturnsHotTier_ForStrongLead()
    {
        var service = new DefaultLeadScoringService();
        var result = service.Score(new LeadScoreRequest(
            CompanySize: 1000,
            HasBudget: true,
            RequestedDemo: true,
            Region: "North America",
            Industry: "FinTech"));

        Assert.Equal("Hot", result.Tier);
        Assert.True(result.Score >= 75);
    }

    [Fact]
    public async Task LeadSubmission_ReturnsReference()
    {
        var client = new MockLeadSubmissionClient();
        var reference = await client.SubmitAsync(
            new LeadSubmission("test@example.com", "Acme", "Q1-campaign", true),
            CancellationToken.None);

        Assert.StartsWith("LEAD-", reference);
    }
}
