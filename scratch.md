# The Idea
### Two library classes 
- CourseRepsotory -> will contain the interface and classes implemeting it. 
- EnrolmentNotifer -> Will contain the interface for notifier and the classes implementing it. 

### Enrolment service  
- takes two interfaces (ICourseRepository, IEnrolmentNotifier) and then provides the enrol option
- when enrol method runs it will check the course repository and then check current number of students and capacity. 
if student can enrol then Enroled++ and send the notification to the student using the studentId and courseId
else throw error. 
- enrol method will return true if the student is enroled successfully else return false; 
- do I have to create the list for storing the Courses for the class which implments the IcourseRepository? because the find function is returning the Course/NULL, same way the save will store the new course in the this Coures list. This makes this module independent of any other modules. 
- do the class impleenting the EnrolmentNotifer have to validate if course exist in course repository? 
- we re passing the interface to the EnrolmentService Module. but How will module know what course are there in course repository? like do we have to pass `Course repositry object` to the class implmenting this interface which will used for validatin if user can enrol in course and enrol him/her/? 
- I am certain the we might have to use the factory design pattern here because accouding the **Depnedency Inversion principle** higher level module should not depend on the lower level modules. so making factory which returns the interface makes sense so higher level modules won't have to make any changes. 



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


#### Hashset in c# 
- [HashSet Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-10.0)


### Some tricks 
        public class EnrolmentService(ICourseRepository courses, IEnrolmentNotifier notifier)
        {
        public bool Enrol(string studentId, string courseId)
        {
                return false;
        }
        }
### Is Equivalent to 
        public class EnrolmentService
        {
        private readonly ICourseRepository courses;
        private readonly IEnrolmentNotifier notifier;

        public EnrolmentService(ICourseRepository courses, IEnrolmentNotifier notifier)
        {
                this.courses = courses;
                this.notifier = notifier;
        }

        public bool Enrol(string studentId, string courseId)
        {
                return false;
        }
        }