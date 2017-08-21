using System;
using Xunit;

namespace Fiver.Design.ImmutableType
{
    public class EmailTests
    {
        [Fact(DisplayName = "New_email_with_all_props_sets_up_all_props")]
        public void New_email_with_all_props_sets_up_all_props()
        {
            var email = new Email(
                            subject: "Hello Immutable Type",
                            from: "james@bond.com",
                            body: "Immutable Types are good for value objects",
                            to: "joker@circus.com");

            Assert.Equal("Hello Immutable Type", email.Subject);
            Assert.Equal("james@bond.com", email.From);
            Assert.Equal("Immutable Types are good for value objects", email.Body);
            Assert.Equal("joker@circus.com", email.To[0]);
        }

        [Fact(DisplayName = "New_email_with_missing_values_throws_exception")]
        public void New_email_with_missing_values_throws_exception()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var email = new Email(
                            subject: "",
                            from: "james@bond.com",
                            body: "Immutable Types are good for value objects",
                            to: "joker@circus.com");
            });

            Assert.Equal(
                expected: "Subject must be set",
                actual: ex.Message);
        }

        [Fact(DisplayName = "Changing_email_returns_new_email_and_leave_orignal_unchanged")]
        public void Changing_email_returns_new_email_and_leave_orignal_unchanged()
        {
            var email = new Email(
                            subject: "Hello Immutable Type",
                            from: "james@bond.com",
                            body: "Immutable Types are good for value objects",
                            to: "joker@circus.com");

            var newEmail = email.AddTo("riddler@puzzled.com");

            Assert.Equal(1, email.To.Count);
            Assert.Equal(2, newEmail.To.Count);
        }
    }
}
