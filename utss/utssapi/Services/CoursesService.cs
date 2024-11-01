using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using utssapi.Models;

namespace utssapi.Services
{
    public class CoursesService
    {
        private readonly HttpClient _httpClient;

        public CoursesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Course>> GetCoursesAsync() 
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("api/Courses");
        }

        public async Task<Course> GetCourseByIdAsync(int id)  
        {
            return await _httpClient.GetFromJsonAsync<Course>($"api/Courses/{id}");
        }

        public async Task UpdateCourseAsync(Course course) 
        {
            await _httpClient.PutAsJsonAsync($"api/Courses/{course.courseId}", course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Courses/{id}");
        }

        public async Task<Course> CreateCourseAsync(Course newCourse)  
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Courses", newCourse);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Course>();
            }
            else
            {
                throw new HttpRequestException($"Failed to add course. Status code: {response.StatusCode}");
            }
        }
    }
}
