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

    public static IConditionStage<TRuleBuilder, TTarget> EndWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, string suffix)
    {
        return @this.VerifiableBy(new EndSecureStringVerifier(suffix));
    }

    public static IConditionStage<TRuleBuilder, TTarget> EndWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, Func<TTarget, string> suffixExtractor)
    {
        return @this.EndWith(new DelegateValueExtractor<TTarget, string>(suffixExtractor));
    }

    public static IConditionStage<TRuleBuilder, TTarget> EndWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, IValueExtractor<TTarget, string> suffixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, SecureString>(
                target => new EndSecureStringVerifier(suffixExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleBuilder, TTarget> Match<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, string pattern)
    {
        return @this.VerifiableBy(new RegularExpressionSecureStringVerifier(pattern));
    }

    public static IConditionStage<TRuleBuilder, TTarget> Match<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, Func<TTarget, string> patternExtractor)
    {
        return @this.Match(new DelegateValueExtractor<TTarget, string>(patternExtractor));
    }

    public static IConditionStage<TRuleBuilder, TTarget> Match<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, IValueExtractor<TTarget, string> patternExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, SecureString>(
                target => new RegularExpressionSecureStringVerifier(patternExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleBuilder, TTarget> StartWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, string prefix)
    {
        return @this.VerifiableBy(new StartSecureStringVerifier(prefix));
    }

    public static IConditionStage<TRuleBuilder, TTarget> StartWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, Func<TTarget, string> prefixExtractor)
    {
        return @this.StartWith(new DelegateValueExtractor<TTarget, string>(prefixExtractor));
    }

    public static IConditionStage<TRuleBuilder, TTarget> StartWith<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this, IValueExtractor<TTarget, string> prefixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, SecureString>(
                target => new StartSecureStringVerifier(prefixExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleBuilder, TTarget> WhiteSpace<TRuleBuilder, TTarget>(this IVerificationStage<TRuleBuilder, TTarget, SecureString> @this)
    {
        return @this.VerifiableBy(new WhiteSpaceSecureStringVerifier());
    }
}