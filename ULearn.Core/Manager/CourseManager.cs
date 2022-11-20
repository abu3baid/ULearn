﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ULearn.Common.Extensions;
using ULearn.DbModel.Models;
using ULearn.DbModel.Models.DB;
using ULearn.ModelView.ModelView;
using ULearn.ModelView.ModelView.Response;
using ULearn.ModelView.Request;

namespace ULearn.Core.Manager
{
    public class CourseManager
    {
        public ulearndbContext _ulearndbContext;
        private IMapper _mapper;

        public CourseManager(ulearndbContext ulearndbContext, IMapper mapper)
        {
            _ulearndbContext = ulearndbContext;
            _mapper = mapper;
        }

        public CourseModel CreateCourse(UserModel currentUser, CourseRequest courseRequest)
        {
            Course course = null;

            course = _ulearndbContext.Courses.Add(new Course
            {
                CourseName = courseRequest.CourseName,
                CourseDescription = courseRequest.CourseDescription,
                TeacherId = currentUser.Id
            }).Entity;

            _ulearndbContext.SaveChanges();
            return _mapper.Map<CourseModel>(course);
        }

        public CourseModel GetCourse(UserModel currentUser, int id)
        {
            var allowedPermissions = new List<string> { "courses_all_view", "course_view" };

            var hasAccess = currentUser.Permissions.Any(a => allowedPermissions.Contains(a.Code));

            var isAllView = currentUser.Permissions.Any(a => allowedPermissions.Equals("courses_all_view"));

            var res = _ulearndbContext.Courses
                                      .Include("Teacher")
                                      .FirstOrDefault(a => (currentUser.IsSuperAdmin 
                                                           || (hasAccess 
                                                                && (isAllView || a.TeacherId == currentUser.Id))) 
                                                           && a.Id == id)
                                      ?? throw new ServiceValidationException("Invalid blog id received");

            return _mapper.Map<CourseModel>(res);
        }

        public CourseResponse GetCourses(int page = 1,
                                     int pageSize = 10,
                                     string sortColumn = "",
                                     string sortDirection = "ascending",
                                     string searchText = "")
        {
            var queryRes = _ulearndbContext.Courses
                                           .Where(a => string.IsNullOrWhiteSpace(searchText)
                                                       || (a.CourseName.Contains(searchText)
                                                       || a.CourseDescription.Contains(sortColumn)));

            if(!string.IsNullOrWhiteSpace(sortColumn)
                && sortDirection.Equals("ascending", StringComparison.InvariantCultureIgnoreCase))
            {
                queryRes = queryRes.OrderBy(sortColumn);
            }
            else if (!string.IsNullOrWhiteSpace(sortColumn)
                && sortDirection.Equals("descending", StringComparison.InvariantCultureIgnoreCase))
            {
                queryRes = queryRes.OrderByDescending(sortColumn);
            }

            var res = queryRes.GetPaged(page, pageSize);

            var userIds = res.Data
                             .Select(a => a.TeacherId)
                             .Distinct()
                             .ToList();

            var users = _ulearndbContext.Users
                                        .Where(a => userIds.Contains(a.Id))
                                        .ToDictionary(a => a.Id, x => _mapper.Map<UserResult>(x));

            var data = new CourseResponse
            {
                Course = _mapper.Map<PagedResult<CourseModel>>(res),
                User = users
            };

            data.Blog.Sortable.Add("Title", "Title");
            data.Blog.Sortable.Add("CreatedDate", "Created Date");

            return data;
        }
    }
}