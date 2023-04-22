using Padutronics.Extensions.System.Security;
using Padutronics.Validation.Verifiers;
using System.Security;
using System.Text.RegularExpressions;

namespace Padutronics.Validation.Extensions.System.Security.Verifiers;

internal sealed class RegularExpressionSecureStringVerifier : Verifier<SecureString>
{
    private readonly Regex regularExpression;

    public RegularExpressionSecureStringVerifier(string pattern) :
        this(new Regex(pattern))
    {
    }

    public RegularExpressionSecureStringVerifier(Regex regularExpression)
    {
        this.regularExpression = regularExpression;
    }

    public override VerificationResult Verify(SecureString value)
    {
        return regularExpression.IsMatch(value.ToUnsecureString())
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}