using Padutronics.Extensions.System.Security;
using Padutronics.Validation.Verifiers;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class ContainSecureStringVerifier : Verifier<SecureString>
{
    private readonly string substring;

    public ContainSecureStringVerifier(string substring)
    {
        this.substring = substring;
    }

    public override VerificationResult Verify(SecureString value)
    {
        return value
            .ToUnsecureString()
            .Contains(substring)
                ? VerificationResults.Success
                : VerificationResults.Failure;
    }
}