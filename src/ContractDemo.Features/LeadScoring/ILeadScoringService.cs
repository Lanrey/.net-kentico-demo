namespace ContractDemo.Features.LeadScoring;

public interface ILeadScoringService
{
    LeadScoreResult Score(LeadScoreRequest request);
}
