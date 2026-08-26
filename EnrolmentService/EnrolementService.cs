// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace EnrolmentService;

using CourseRepository;
using EnrolmentNotifier;
public class EnrolementService(ICourseRepository courses, IEnrolmentNotifier notifier)
{
    public bool Enroll(string studentId, string courseId)
    {
        return false;
    }
}
