using Padutronics.Extensions.System.Security;
using Padutronics.Validation.Verifiers;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class StartSecureStringVerifier : Verifier<SecureString>
{
    private readonly string prefix;

    public StartSecureStringVerifier(string prefix)
    {
        this.prefix = prefix;
    }

    public override VerificationResult Verify(SecureString value)
    {
        return value
            .ToUnsecureString()
            .StartsWith(prefix)
                ? VerificationResults.Success
                : VerificationResults.Failure;
    }
}