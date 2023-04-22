using Padutronics.Extensions.System.Security;
using Padutronics.Validation.Verifiers;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class EndSecureStringVerifier : Verifier<SecureString>
{
    private readonly string suffix;

    public EndSecureStringVerifier(string suffix)
    {
        this.suffix = suffix;
    }

    public override VerificationResult Verify(SecureString value)
    {
        return value
            .ToUnsecureString()
            .EndsWith(suffix)
                ? VerificationResults.Success
                : VerificationResults.Failure;
    }
}