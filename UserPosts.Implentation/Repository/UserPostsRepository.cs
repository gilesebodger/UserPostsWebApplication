using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Implentation.Model;

namespace UserPosts.Implentation.Repository
{
    public class UserPostsRepository : IUserPostsRepository
    {

        public async Task<UserRaw> GetUser(int userId)
        {
            var client = new HttpClient();
            var url = $"https://jsonplaceholder.typicode.com/users/{userId}";
            var result = await client.GetAsync(url);
            var jsonContent = await result.Content.ReadAsStringAsync();
            var returnValue = JsonConvert.DeserializeObject<UserRaw>(jsonContent);
            client.Dispose();

            return returnValue;
        }

        public async Task<IEnumerable<PostRaw>> GetUserPosts(int userId)
        {
            var url = $"https://jsonplaceholder.typicode.com/users/{userId}/posts";
            return await GetCollectionInternal<PostRaw>(url);
        }


        public async Task<IEnumerable<UserRaw>> GetAllUsers()
        {
            var url = $"https://jsonplaceholder.typicode.com/users";
            return await GetCollectionInternal<UserRaw>(url);

        }

        public async Task<IEnumerable<PostRaw>> GetAllPosts()
        {
            var url = $"https://jsonplaceholder.typicode.com/posts";
            return await GetCollectionInternal<PostRaw>(url);
        }

        private async Task<IEnumerable<T>> GetCollectionInternal<T>(string url)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(url);
            var jsonContent = await result.Content.ReadAsStringAsync();
            var returnValue = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonContent);
            client.Dispose();

            return returnValue;
        }
    }
}
