// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace EnrolmentService;

using CourseRepository;
using EnrolmentNotifier;
public class CourseEnrolmentService(ICourseRepository courseRepo, IEnrolmentNotifier notifier)
{
    public bool Enrol(string studentId, string courseId)
    {
        Course? course = courseRepo.Find(courseId);

        // check if course exist
        if (course == null)
        {
            Console.WriteLine($"Course : {courseId} not found in course Repository ");
            return false;
        }

        // check the capacity and validate if student can be enroled
        int capacity = course.Capacity, enrolled = course.Enroled;
        // If the number already enrolled is greater than or equal to capacity,
        // the course is full and enrollment should fail.
        if (enrolled >= capacity)
        {
            Console.WriteLine($"Capacity Full for course {courseId}");
            return false;
        }
        courseRepo.Save(new Course(courseId, capacity, enrolled + 1));
        notifier.SendConfirmation(studentId, courseId);


        return true;
    }
}
