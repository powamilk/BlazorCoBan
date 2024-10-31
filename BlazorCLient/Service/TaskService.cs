using Blazor.Share.Models;

namespace BlazorCLient.Service
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Lấy tất cả các TaskItem
        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskItem>>("api/task");
        }

        // Lấy TaskItem theo ID
        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TaskItem>($"api/task/{id}");
        }

        // Tạo mới TaskItem
        public async Task CreateTaskAsync(TaskItem task)
        {
            await _httpClient.PostAsJsonAsync("api/task", task);
        }

        // Cập nhật TaskItem
        public async Task UpdateTaskAsync(int id, TaskItem task)
        {
            await _httpClient.PutAsJsonAsync($"api/task/{id}", task);
        }

        // Xóa TaskItem
        public async Task DeleteTaskAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/task/{id}");
        }
    }
}
