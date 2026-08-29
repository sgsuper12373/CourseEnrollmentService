using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EnrolmentService;
using EnrolmentNotifier;
using CourseRepository;

namespace CourseEnrollmentUnitTests;

class TestNotifier : IEnrolmentNotifier
{
    public List<(string studentId, string courseId)> Calls { get; } = new();
    public void SendConfirmation(string studentId, string courseId)
    {
        Calls.Add((studentId, courseId));
    }
}

[TestClass]
public class EnrolmentServiceTests
{
    [TestMethod]
    public void Enrol_Succeeds_WhenSpaceAvailable_NotifiesAndSaves()
    {
        ICourseRepository repo = new InMemoryCourseRepository();
        repo.Save(new Course("C1", 2, 1));
        TestNotifier notifier = new TestNotifier();
        CourseEnrolmentService service = new EnrolmentService.CourseEnrolmentService(repo, notifier);

        bool result = service.Enrol("S1", "C1");

        Assert.IsTrue(result);
        Course? updated = repo.Find("C1");
        Assert.IsNotNull(updated);
        Assert.AreEqual(2, updated!.Enroled);
        Assert.IsNotEmpty(notifier.Calls);
        Assert.AreEqual(("S1", "C1"), notifier.Calls[0]);
    }

    [TestMethod]
    public void Enrol_Fails_WhenCourseNotFound_NotifiesNotCalled()
    {
        ICourseRepository repo = new InMemoryCourseRepository();
        TestNotifier notifier = new TestNotifier();
        CourseEnrolmentService service = new EnrolmentService.CourseEnrolmentService(repo, notifier);

        bool result = service.Enrol("S1", "NON_EXISTENT");

        Assert.IsFalse(result);
        Assert.IsEmpty(notifier.Calls); // should empty ans course "NON_EXISTENT" not added to course repository
    }

    [TestMethod]
    public void Enrol_Fails_WhenCourseFull_NotifiesNotCalled()
    {
        ICourseRepository repo = new InMemoryCourseRepository();
        repo.Save(new Course("C2", 1, 1));
        TestNotifier notifier = new TestNotifier();
        CourseEnrolmentService service = new EnrolmentService.CourseEnrolmentService(repo, notifier);

        bool result = service.Enrol("S2", "C2");

        Assert.IsFalse(result);
        Assert.IsEmpty(notifier.Calls);
    }
}
