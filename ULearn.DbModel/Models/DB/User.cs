using System;
using System.Collections.Generic;
using ULearn.DbModel.Models.DB.RoleModels;

#nullable disable

namespace ULearn.DbModel.Models.DB
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte IsArchived { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
