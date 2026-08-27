// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CourseRepository;

public class InMemoryCourseRepository : ICourseRepository
{

    // Set is used for storing the courses in memory
    private Dictionary<string, Course> _courseRepo = new Dictionary<string, Course>(); 
    public Course? Find(string courseId)
    {
        // if key exist in the dictionary return the object stored corresponding to key -> O(1) 
        if (_courseRepo.ContainsKey(courseId))
        {
            return _courseRepo[courseId];
        }

        return null;
    }

    public void Save(Course course)
    {
        // if course already exist the update it
        if (this.Find(course.Id) != null)
        {
            _courseRepo[course.Id] = course;
        }

        // Else add the course 
        _courseRepo.Add(course.Id, course);
    }

}
