using ContractDemo.Features.LeadScoring;
using ContractDemo.Integrations.Leads;
using Microsoft.AspNetCore.Mvc;

namespace ContractDemo.Web.Controllers;

[ApiController]
[Route("api/leads")]
public sealed class LeadController : ControllerBase
{
    private readonly ILeadScoringService _leadScoringService;
    private readonly ILeadSubmissionClient _leadSubmissionClient;

    public LeadController(ILeadScoringService leadScoringService, ILeadSubmissionClient leadSubmissionClient)
    {
        _leadScoringService = leadScoringService;
        _leadSubmissionClient = leadSubmissionClient;
    }

    [HttpPost("score")]
    public ActionResult<LeadScoreResult> Score([FromBody] LeadScoreRequest request)
    {
        var result = _leadScoringService.Score(request);
        return Ok(result);
    }

    [HttpPost("submit")]
    public async Task<ActionResult<object>> Submit([FromBody] LeadSubmission submission, CancellationToken cancellationToken)
    {
        if (!submission.AcceptedConsent)
        {
            return BadRequest(new { message = "Consent is required." });
        }

        var reference = await _leadSubmissionClient.SubmitAsync(submission, cancellationToken);
        return Ok(new { message = "Lead submitted.", reference });
    }
}
