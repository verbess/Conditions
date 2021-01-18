**Don't use this class library if you have high performance requirements！**

# Condition

Condition is a cross platform portable class library that helps developers write pre- and postcondition validations in a fluent manner. Writing these validations is easy and it improves the readability and maintainability of code.

## Usage

```csharp
public ICollection GetData(Nullable<int> id, string xml, IEnumerable<int> col)
{
    // Check all preconditions:
    Condition.Requires(id, "id")
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
        .IsNotEqualTo(128);   // throws ArgumentException on failure

    Condition.Requires(xml, "xml")
        .StartsWith("<data>") // throws ArgumentException on failure
        .EndsWith("</data>") // throws ArgumentException on failure
        .Evaluate(xml.Contains("abc") || xml.Contains("cba")); // arg ex

    Condition.Requires(col, "col")
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsEmpty()            // throws ArgumentException on failure
        .Evaluate(c => c.Contains(id.Value) || c.Contains(0)); // arg ex

    // Do some work

    // Example: Call a method that should not return null
    object result = BuildResults(xml, col);

    // Check all postconditions:
    Condition.Ensures(result, "result")
        .IsOfType(typeof(ICollection)); // throws PostconditionException on failure

    return (ICollection)result;
}
    
public static int[] Multiply(int[] left, int[] right)
{
    Condition.Requires(left, "left").IsNotNull();
    
    // You can add an optional description to each check
    Condition.Requires(right, "right")
        .IsNotNull()
        .HasLength(left.Length, "left and right should have the same length");
    
    // Do multiplication
}
```
    
A particular validation is executed immediately when it's method is called, and therefore all checks are executed in the order in which they are written:

### C# 6

C# 6 compiler provides easier way for accessing extension methods. With `using static Condition;` you have no longer to prefix `Requires` and `Ensures` methods with name of `Condition` static class. 

For example:

```csharp
namespace Foo
{
    using static Condition; 
    
    public class Bar
    {
        public void Buzz(object arg)
        {
            Required(arg).IsNotNull();
        }
    }    
}
```

## With thanks to
- forked from [conditions](https://github.com/ghuntley/conditions) by [Geoffrey Huntley](https://github.com/ghuntley)
