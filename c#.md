### Tuples

Tuples are **an ordered sequence of values with a fixed length**. **Each element of a tuple has a `type` and an `optional name`**.

```csharp
var pt = (X: 1, Y: 2);

var slope = (double)pt.Y / (double)pt.X;
Console.WriteLine($"A line from the origin to the point {pt} has a slope of {slope}.");
```

This will output:

```
A line from the origin to the point (X: 1, Y: 2) has a slope of 2.
```

You can reassign any member of a tuple.

```csharp
pt.X = 3;
```

You can also create a new tuple that's a modified copy of the original using a with expression.

```csharp
var pt2 = pt with { Y = 4 };
Console.WriteLine($"A line from the origin to the point {pt2} has a slope of {pt2.Y / pt2.X}.");
```

This will output:

```
A line from the origin to the point (X: 3, Y: 4) has a slope of 1.33333333333333.
```

Tuples are **structural** types. In other words, tuple types don't have names like `string` or `int`.

In mathematics and computer science, `arity` refers to the number of arguments or components a function or structure has. For a tuple, it's the _count of items_ in its sequence.

You can assign a tuple to a tuple with the same arity and types even if the members have different names.

```csharp
var pt = (X: 1, Y: 2);
var subscript = (A: 0, B: 0);
subscript = pt;
Console.WriteLine(subscript);
```

This will output:

```
(1, 2)
```

### Records

Records are **a reference type that provides built-in functionality for value equality**. They are useful for defining data structures that need to be compared based on their content rather than their reference.

```csharp
record Point(int X, int Y);

var p1 = new Point(1, 2);
var p2 = new Point(1, 2);
Console.WriteLine(p1 == p2);  // True
Console.WriteLine(p1.Equals(p2));  // True
```

Different from tuples, records are **named types**. They can have methods, properties, and other members just like classes.

```csharp
public record Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

public static void Main()
{
    Point pt = new Point(1, 1);
    double slope = pt.Slope();
    Console.WriteLine($"The slope of {pt} is {slope}");
}
```

This will output:

```
The slope of (1, 1) is 1.
```

### Struct, class, and interface types

All named types in C# are either `class` or `struct` types. A `class` is a reference type. A `struct` is a _value_ type.

- **Variables of a value type** store the contents of the instance inline in memory. In other words, a `record struct Point` stores two integers: X and Y.
- **Variables of a reference type** store a reference, or pointer, to the storage for the instance. In other words, a record class Point stores a reference to a block of memory that holds the values for X and Y.

```csharp
public class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
}
public struct PointStruct
{
    public int X { get; set; }
    public int Y { get; set; }
}
public static void Main()
{
    PointClass pc1 = new PointClass { X = 1, Y = 2 };
    PointClass pc2 = pc1; // pc2 references the same object as pc1
    pc2.X = 3; // Changes pc1.X to 3
    Console.WriteLine($"pc1: {pc1.X}, pc2: {pc2.X}"); // Outputs: pc1: 3, pc2: 3

    PointStruct ps1 = new PointStruct { X = 1, Y = 2 };
    PointStruct ps2 = ps1; // ps2 is a copy of ps1
    ps2.X = 3; // Changes only ps2.X
    Console.WriteLine($"ps1: {ps1.X}, ps2: {ps2.X}"); // Outputs: ps1: 1, ps2: 3
}
```

This will output:

```
pc1: 3, pc2: 3
ps1: 1, ps2: 3
```

You can also define interface types to declare behavioral contracts that different types must implement. Both struct and class types can implement interfaces.

### A basic list example

```csharp
List<string> names = ["Bilguun", "Ana", "Felipe"];
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
```

This will output:

```
Hello BILGUUN!
Hello ANA!
Hello FELIPE!
```

## Modify list contents

You can modify the contents of a list by adding or removing items. Here's an example:

```csharp
Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
```

This will output:

```
Hello BILGUUN!
Hello FELIPE!
Hello MARIA!
Hello BILL!
```

The `List<T>` enables you to reference individual items by index as well. You access items using the [ and ] tokens.

```csharp
Console.WriteLine($"My name is {names[0]}.");
Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
Console.WriteLine($"The list has {names.Count} people in it");
```
This will output:

```
My name is Bilguun.
I've added Maria and Bill to the list.
The list has 4 people in it
```

## Search and sort lists
The `IndexOf` method searches for an item and returns the index of the item. If the item isn't in the list, `IndexOf` returns `-1`.
```csharp
var index = names.IndexOf("Felipe");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}

index = names.IndexOf("Not Found");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}
```

The items in your list can be sorted as well. The Sort method sorts all the items in the list in their normal order (alphabetically for strings).

```csharp
names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
```

This will output:

```
Hello BILGUUN!
Hello BILL!
Hello FELIPE!
Hello MARIA!
```