using Padutronics.Validation.Extensions.System.Security.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers.Adapters;
using System;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security;

public static class SecureStringVerificationBuilderExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, SecureString> @this, string substring)
    {
        return @this.VerifiableBy(new ContainSecureStringVerifier(substring));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, SecureString> @this, Func<TTarget, string> substringExtractor)
    {
        return @this.Contain(new DelegateValueExtractor<TTarget, string>(substringExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, SecureString> @this, IValueExtractor<TTarget, string> substringExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, SecureString>(
                target => new ContainSecureStringVerifier(substringExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleBuilder, TTarget> Empty<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this)
    {
        return @this.VerifiableBy(new EmptySecureStringVerifier());
    }
}