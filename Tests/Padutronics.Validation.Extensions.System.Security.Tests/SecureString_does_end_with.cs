using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Security.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Tests;

[TestFixture]
internal sealed class SecureString_does_end_with
{
    private sealed class ModelValidator : Validator<Model<SecureString>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<SecureString>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Does.EndWith("llo")
                .WithMessage("Value must end with 'llo'");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_ends_with_specified_substring()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<SecureString>(new SecureString());
        model.Value.AppendChar('H');
        model.Value.AppendChar('e');
        model.Value.AppendChar('l');
        model.Value.AppendChar('l');
        model.Value.AppendChar('o');

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_does_not_end_with_specified_substring()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<SecureString>(new SecureString());
        model.Value.AppendChar('W');
        model.Value.AppendChar('o');
        model.Value.AppendChar('r');
        model.Value.AppendChar('l');
        model.Value.AppendChar('d');

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}