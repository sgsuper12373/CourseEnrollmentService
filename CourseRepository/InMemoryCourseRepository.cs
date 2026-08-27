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
    public HashSet<Course> _courseRepo = new HashSet<Course>();
    public InMemoryCourseRepository()
    {

    }
    public Course? Find(string courseId)
    {
        for (int i = 0; i < _courseRepo.Count; i++)
        {
            if (_courseRepo.ElementAt(i).Id == courseId)
            {
                return _courseRepo.ElementAt(i);
            }
        }
        return null;
    }

    public void Save(Course course)
    {
        _courseRepo.Add(course);
    }

}
