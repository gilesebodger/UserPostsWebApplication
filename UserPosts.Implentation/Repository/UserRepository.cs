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
    public class UserRepository : IUserRepository
    {

        public async Task<User> GetUser(int userId)
        {
            //using (var client = new HttpClient())
            //{
                //client.BaseAddress = new Uri($"https://jsonplaceholder.typicode.com/users/{userId}"
            var client = new HttpClient();
            var url = $"https://jsonplaceholder.typicode.com/users/{userId}";
            var result = await client.GetAsync(url);
            var jsonContent = await result.Content.ReadAsStringAsync();
            var returnValue = JsonConvert.DeserializeObject<User>(jsonContent);
            client.Dispose();

            return returnValue;

            //}


            //    HttpClient client = new HttpClient();
            //client.BaseAddress = ;
            //client.GetAsync()

            //// Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
