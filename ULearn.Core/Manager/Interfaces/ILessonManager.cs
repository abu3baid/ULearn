using ULearn.ModelView.ModelView;
using ULearn.ModelView.Request;
using ULearn.ModelView.Response;

namespace ULearn.Core.Manager.Interfaces
{
    public interface ILessonManager
    {
        void ArchiveLesson(UserModel currentUser, int id);
        LessonModel CreateLesson(UserModel currentUser, LessonRequest lessonRequest);
        LessonModel GetLesson(UserModel currentUser, int id);
        LessonResponse GetLessons(int page = 1,
                                  int pageSize = 10, 
                                  string sortColumn = "", 
                                  string sortDirection = "ascending", 
                                  string searchText = "");
        CourseModel PutLesson(UserModel currentUser, LessonRequest LessonRequest);
    }
}