using Padutronics.Extensions.System.Security;
using Padutronics.Validation.Verifiers;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class WhiteSpaceSecureStringVerifier : Verifier<SecureString>
{
    public override VerificationResult Verify(SecureString value)
    {
        return value is not null && string.IsNullOrWhiteSpace(value.ToUnsecureString())
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}