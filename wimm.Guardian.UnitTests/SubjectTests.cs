using System;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class SubjectTests
    {
        [Fact(DisplayName = "Subject throws for null name")]
        public void Subject_Throws_For_Null_Name()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Subject<int>(0, null));
        }

        [Fact(DisplayName = "Subject has correct name")]
        public void Subject_Has_Correct_Name()
        {
            var name = "name";
            var subject = new Subject<int>(42, name);
            Assert.Equal(name, subject.Name);
        }

        [Fact(DisplayName = "Subject allows null value")]
        public void Subject_Allows_Null_Value()
        {
            var value = null as string;
            var subject = new Subject<string>(value, "name");
        }

        [Fact(DisplayName = "Subject has correct value for value type")]
        public void Subject_Has_Correct_Value_For_Value_Type()
        {
            var value = 42;
            var subject = new Subject<int>(value, "name");
            Assert.Equal(value, subject.Value);
        }

        [Fact(DisplayName = "Subject has reference equal value for reference type")]
        public void Subject_Has_Reference_Equal_Value_For_Reference_Type()
        {
            var value = new object();
            var subject = new Subject<object>(value, "name");
            Assert.Same(value, subject.Value);
        }
    }
}
