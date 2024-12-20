using System.Net.Http.Json;
using BrandonChong_FinalTest.Model;

namespace BrandonChong_FinalTest
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        public async Task<List<PostRecord>> GetPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PostRecord>>("posts");
        }

        public async Task<PostRecord> AddPostAsync(PostRecord newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", newPost);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<PostRecord>()
                : null;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"posts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
