using System;
using System.Collections.Generic;
using Xunit;
using TestDevSkiller;

namespace TestProject1
{
    public class ObjectPrinterTests
    {
        public class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<TestClass> Children { get; set; }

            public object Child { get; set; }
        }

        [Fact]
        public void Print_SimpleAndNestedCollections_PrintsCorrectly()
        {
            var obj = new TestClass
            {
                Id = 1,
                Name = "Root",
                Children = new List<TestClass>
                {
                    new TestClass { Id = 2, Name = "Child1", Children = new List<TestClass>() },
                    new TestClass { Id = 3, Name = "Child2", Children = new List<TestClass>
                        {
                            new TestClass { Id = 4, Name = "Grandchild", Children = new List<TestClass>() }
                        }
                    }
                },
                Child = new
                {
                    Name = "Child3"
                }
            };

            var printer = new ObjectPrinter();
            var result = printer.Print(obj);
            var expected = new List<string>
            {
                "1",
                "Root",
                "*2",
                "*Child1",
                "*3",
                "*Child2",
                "**4",
                "**Grandchild"
            };
            Assert.Contains("1", result);
            Assert.Contains("Root", result);
            Assert.Contains("*2", result);
            Assert.Contains("*Child1", result);
            Assert.Contains("*3", result);
            Assert.Contains("*Child2", result);
            Assert.Contains("**4", result);
            Assert.Contains("**Grandchild", result);
            Assert.True(result.Count >= 8); // Should have at least all fields
        }
    }
}
