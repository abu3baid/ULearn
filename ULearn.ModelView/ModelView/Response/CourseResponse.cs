using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULearn.Common.Extensions;

namespace ULearn.ModelView.ModelView.Response
{
    public class CourseResponse
    {
        public PagedResult<CourseModel> Course { get; set; }

        public Dictionary<int, UserResult> User { get; set; }
    }
}
