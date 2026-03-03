namespace ContractDemo.Integrations.Leads;

public interface ILeadSubmissionClient
{
    Task<string> SubmitAsync(LeadSubmission submission, CancellationToken cancellationToken);
}
