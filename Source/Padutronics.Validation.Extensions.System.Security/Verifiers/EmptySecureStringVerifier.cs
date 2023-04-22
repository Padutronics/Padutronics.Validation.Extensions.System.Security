using Padutronics.Validation.Verifiers;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class EmptySecureStringVerifier : Verifier<SecureString>
{
    public override VerificationResult Verify(SecureString value)
    {
        return value.Length == 0
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}