using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Security.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;
using System.Security;

namespace Padutronics.Validation.Extensions.System.Security.Tests;

[TestFixture]
internal sealed class SecureString_is_white_space
{
    private sealed class ModelValidator : Validator<Model<SecureString>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<SecureString>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.WhiteSpace()
                .WithMessage("Value must be white space.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_white_space()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<SecureString>(new SecureString());
        model.Value.AppendChar(' ');

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_not_white_space()
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
        Assert.That(result.IsSucceeded, Is.False);
    }
}