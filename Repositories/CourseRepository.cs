using Academy_2024.Models;

namespace Academy_2024.Repositories
{
    public class CourseRepository
    {
        private static List<Course> Courses = new List<Course>
        {
            new Course{Id=1,CourseName=".net Course"}

        };
        public List<Course> GetAll() { return Courses; }

        public Course? GetById(int id)
        {
            foreach(var course in Courses)
            {
                if (course.Id == id) return course;
            }
            return null;
        }

        public void Create(Course data) 
        {
            if (data == null) return;
            Courses.Add(data);
        }

        public Course? Update(int id,Course data)
        {
            foreach (var course in Courses)
            {
                if(course.Id==id)
                {
                    course.CourseName = data.CourseName;
                    return course;
                }
            }
            return null;
        }

        public bool Delete(int id) 
        {
            foreach (var course in Courses)
            {
                if (course.Id==id) 
                {
                    Courses.Remove(course);
                    return true;
                }
            }
            return false;
        }
        

    }
}
