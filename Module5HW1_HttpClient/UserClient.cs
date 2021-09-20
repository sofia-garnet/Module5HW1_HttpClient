using Module5HW1.Models;
using Module5HW1.Models.Responses.Error;
using Module5HW1.Models.Responses.List;
using Module5HW1.Models.Responses.POST;
using Module5HW1.Models.Responses.Single;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1
{
    public class UserClient : IUserClient
    {
        public async Task Run()
        {
            HttpClientSingleton.Client.DefaultRequestHeaders.Accept.Clear();
            HttpClientSingleton.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Print(await GetListUsers(2));
            Print(await GetSingleUser(2));
            Print(await GetSingleUser(23));
            Print(await GetListResources());
            Print(await GetSingleResource(2));
            Print(await GetSingleResource(23));
            Print(await PostCreateUser("morpheus", "leader"));
            Print(await PutUpdateUser(2, "morpheus", "zion resident"));
            Print(await PatchUpdateUser(2, "morpheus", "zion resident"));
            Print(await DeleteUser(2));
            Print(await PostRegisterUser("eve.holt@reqres.in", "pistol"));
            Print(await PostRegisterUser("eve.holt@reqres.in", null));
            Print(await PostLoginUser("eve.holt@reqres.in", "cityslicka"));
            Print(await PostLoginUser("eve.holt@reqres.in", null));
            Print(await GetDelayedResponse(3));

        }

        public async Task<Response<T>> Message<T>(HttpMethod method, string uri, Dictionary<string, string> postParams = null) where T : class
        {
            var message = new HttpRequestMessage();
            message.Method = method;
            message.RequestUri = new Uri(uri);
            if (postParams != null)
                message.Content = new FormUrlEncodedContent(postParams);
            Response<T> requestResponse = new Response<T>();
            T result = null;
            var response = await HttpClientSingleton.Client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(resultString);
                requestResponse.Code = (int)response.StatusCode;
                requestResponse.ResponseData = result;
            } 
            else
            {
                var resultString = await response.Content.ReadAsStringAsync();
                requestResponse.Code = (int)response.StatusCode;
                requestResponse.Message = resultString;
                requestResponse.ReasonePhrase = response.ReasonPhrase;
                requestResponse.ResponseData = result;
            }
            return requestResponse;
        }

        public async Task<Response<ResponseList<ListUsersResponseData>>> GetListUsers(int page)
        {
            return await Message<ResponseList<ListUsersResponseData>>(HttpMethod.Get, $"https://reqres.in/api/users?page={page}");
        }

        public async Task<Response<ResponseSingle<UserResponseData>>> GetSingleUser(int id)
        {
            return await Message<ResponseSingle<UserResponseData>>(HttpMethod.Get, $"https://reqres.in/api/users/{id}");
        }

        public async Task<Response<ResponseList<ListResourceData>>> GetListResources()
        { 
            return await Message<ResponseList<ListResourceData>>(HttpMethod.Get, "https://reqres.in/api/unknown");
        }

        public async Task<Response<ResponseSingle<SingleResourceData>>> GetSingleResource(int id)
        {
            return await Message <ResponseSingle<SingleResourceData>>(HttpMethod.Get, $"https://reqres.in/api/unknown/{id}");
        }

        public async Task<Response<CreateUserResponse>> PostCreateUser(string name, string job)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("name", name);
            @params.Add("job", job);
            return await Message<CreateUserResponse>(HttpMethod.Post, $"https://reqres.in/api/users", @params);
        }

        public async Task<Response<UpdateUserResponse>> PutUpdateUser(int id, string name, string job)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("name", name);
            @params.Add("job", job);
            return await Message<UpdateUserResponse>(HttpMethod.Put, $"https://reqres.in/api/users/{id}", @params);
        }

            public async Task<Response<UpdateUserResponse>> PatchUpdateUser(int id, string name, string job)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("name", name);
            @params.Add("job", job);
            return await Message<UpdateUserResponse>(HttpMethod.Patch, $"https://reqres.in/api/users/{id}", @params);
        }

        public async Task<Response<Object>> DeleteUser(int id)
        {
            return await Message<Object>(HttpMethod.Delete, $"https://reqres.in/api/users/{id}");
        }

        public async Task<Response<LoginUserResponse>> PostRegisterUser(string email, string password)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("email", email);
            @params.Add("password", password);
            return await Message<LoginUserResponse>(HttpMethod.Post, $"https://reqres.in/api/register", @params);
        }

        public async Task<Response<LoginUserResponse>> PostLoginUser(string email, string password)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            @params.Add("email", email);
            @params.Add("password", password);
            return await Message<LoginUserResponse>(HttpMethod.Post, $"https://reqres.in/api/login", @params);
        }

        public async Task<Response<ResponseList<ListUsersResponseData>>> GetDelayedResponse(int delay)
        {
            return await Message<ResponseList<ListUsersResponseData>>(HttpMethod.Get, $"https://reqres.in/api/users?delay={delay}");
        }

        public void Print<T>(T t)
        {
            if ((int)Console.ForegroundColor + 1 > 15)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            Console.ForegroundColor = Console.ForegroundColor + 1;
            Console.WriteLine("Request response: {0}{1}{2}", Environment.NewLine, t, Environment.NewLine);
            
        }
    }

}
