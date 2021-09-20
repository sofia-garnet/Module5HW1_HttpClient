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
    public interface IUserClient
    {
        public  Task<Response<T>> Message<T>(HttpMethod method, string uri, Dictionary<string, string> postParams = null) where T : class;

        public  Task<Response<ResponseList<ListUsersResponseData>>> GetListUsers(int page);

        public  Task<Response<ResponseSingle<UserResponseData>>> GetSingleUser(int id);

        public  Task<Response<ResponseList<ListResourceData>>> GetListResources();

        public  Task<Response<ResponseSingle<SingleResourceData>>> GetSingleResource(int id);

        public  Task<Response<CreateUserResponse>> PostCreateUser(string name, string job);

        public  Task<Response<UpdateUserResponse>> PutUpdateUser(int id, string name, string job);

        public  Task<Response<UpdateUserResponse>> PatchUpdateUser(int id, string name, string job);

        public  Task<Response<Object>> DeleteUser(int id);

        public  Task<Response<LoginUserResponse>> PostRegisterUser(string email, string password);

        public  Task<Response<LoginUserResponse>> PostLoginUser(string email, string password);

        public  Task<Response<ResponseList<ListUsersResponseData>>> GetDelayedResponse(int delay);
    }

}
