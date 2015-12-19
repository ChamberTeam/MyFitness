namespace MyFitness.Universal.Services
{
    using Models;
    using MyFitness.Universal.Helpers;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UsersService : HttpClientHelper
    {
        public UsersService()
            : base()
        {
        }

        public UsersService(HttpClient httpClient)
           : base(httpClient)
        {
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await this.GetCollection<User>("users");
            return users;
        }

        public async Task<User> GetById(string id)
        {
            var user = await this.Get<User>($"users/{id}");
            return user;
        }
    }
}