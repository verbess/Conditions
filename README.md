**Don't use this class library if you have high performance requirements！**

# Conditions

Condition is a cross platform portable class library that helps developers write pre- and post-condition validations in a fluent manner. Writing these validations is easy and it improves the readability and maintainability of code.

## Usage

```csharp
public ICollection GetData(Nullable<int> id, string xml, IEnumerable<int> col)
{
    // Check all pre-conditions:
    Condition.Requires(id, "id")
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
        .IsNotEqualTo(128);   // throws ArgumentException on failure

    xml.Requires("xml")
        .StartsWith("<data>") // throws ArgumentException on failure
        .EndsWith("</data>"); // throws ArgumentException on failure

    col.Requires()
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsEmpty();           // throws ArgumentException on failure

    // Do some work

    // Example: Call a method that should not return null
    object result = BuildResults(xml, col);

    // Check all post-conditions:
    Condition.Requires(result, "result")
        .IsType(typeof(ICollection)); // throws ArgumentException on failure

    return (ICollection)result;
}
    
public static int[] Multiply(int[] left, int[] right)
{
    Condition.Requires(left, "left").IsNotNull();

    // You can add an optional description to each check
    Condition.Requires(right, "right")
        .IsNotNull();

    // Do multiplication
}
```
    
A particular validation is executed immediately when it's method is called, and therefore all checks are executed in the order in which they are written:

## With thanks to
- forked from [conditions](https://github.com/ghuntley/conditions) by [Geoffrey Huntley](https://github.com/ghuntley)