# The Idea
### Two library classes 
- CourseRepsotory -> will contain the interface and classes implemeting it. 
- EnrollmentNotifer -> Will contain the interface for notifier and the classes implementing it. 

### Enrollment service  
- takes two interfaces (ICourseRepository, IEnrollmentNotifier) and then provides the enroll option 



#### What is record in C#   

- [C# documentation](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records)
        // Record class — assignment copies the reference
        var p1 = new Person("Grace", "Hopper");
        var p2 = p1; // p1 and p2 point to the same object:
        Console.WriteLine(ReferenceEquals(p1, p2)); // True

        // Record struct — assignment copies the data
        var c1 = new Coordinate(47.6062, -122.3321);
        var c2 = c1;
        c2.Longitude = 0.0; // mutating c2 doesn't affect c1
        Console.WriteLine(c1.Longitude); // -122.3321
        Console.WriteLine(c2.Longitude); // 0
-  record keyword defines a reference type that is specifically designed for immutable or value-centric data models.
- Choose record class when you need inheritance or when instances are large enough that copying would be expensive.
- Choose record struct for small, self-contained data where value-type copy semantics are appropriate
- records encourage immutability, changing a single property requires a way to copy the object while modifying specific values. C# provides the `with` expression for this exact scenario
- Automatically generates a clean, formatted `ToString()` method that outputs the type name along with all property names and their values out-of-the-box.
- Records automatically generate a `Deconstruct` method, allowing you to easily unpack a record's properties into individual variables

#### what is sealed keyword in c# 
- The `sealed` keyword prevents other classes or records from inheriting from Course.