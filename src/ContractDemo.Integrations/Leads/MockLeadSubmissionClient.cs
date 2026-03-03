namespace ContractDemo.Integrations.Leads;

public sealed class MockLeadSubmissionClient : ILeadSubmissionClient
{
    public Task<string> SubmitAsync(LeadSubmission submission, CancellationToken cancellationToken)
    {
        var reference = $"LEAD-{DateTime.UtcNow:yyyyMMddHHmmss}";
        return Task.FromResult(reference);
    }
}
