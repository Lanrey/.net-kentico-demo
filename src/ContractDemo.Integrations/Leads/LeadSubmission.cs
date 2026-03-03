using System.ComponentModel.DataAnnotations;

namespace ContractDemo.Integrations.Leads;

public sealed record LeadSubmission(
    [property: Required, EmailAddress] string Email,
    [property: Required] string Company,
    [property: Required] string Campaign,
    bool AcceptedConsent
);
