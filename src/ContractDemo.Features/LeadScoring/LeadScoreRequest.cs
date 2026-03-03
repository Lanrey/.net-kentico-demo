namespace ContractDemo.Features.LeadScoring;

public sealed record LeadScoreRequest(
    int CompanySize,
    bool HasBudget,
    bool RequestedDemo,
    string Region,
    string Industry
);
