namespace ContractDemo.Features.LeadScoring;

public sealed class DefaultLeadScoringService : ILeadScoringService
{
    public LeadScoreResult Score(LeadScoreRequest request)
    {
        var score = 0;

        score += request.CompanySize switch
        {
            >= 1000 => 40,
            >= 250 => 25,
            >= 50 => 15,
            _ => 8
        };

        if (request.HasBudget)
        {
            score += 20;
        }

        if (request.RequestedDemo)
        {
            score += 20;
        }

        if (request.Region is "North America" or "Europe")
        {
            score += 10;
        }

        if (request.Industry is "FinTech" or "HealthTech")
        {
            score += 10;
        }

        var tier = score switch
        {
            >= 75 => "Hot",
            >= 50 => "Warm",
            _ => "Cold"
        };

        var reasoning = $"Scored {score} based on company profile, intent and segment fit.";
        return new LeadScoreResult(score, tier, reasoning);
    }
}
