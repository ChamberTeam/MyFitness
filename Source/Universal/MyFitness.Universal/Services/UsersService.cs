namespace MyFitness.Universal.Services
{
    using Models;
    using MyFitness.Universal.Helpers;
    using System.Collections.Generic;
    using Windows.Web.Http;
    using System.Threading.Tasks;
    using System;
    using Constants;
    using Newtonsoft.Json;
    using ViewModels;

    public class UsersService : HttpClientHelper
    {
        public UsersService()
            :base()
        {
        }

        public UsersService(HttpClient httpClient)
           : base(httpClient)
        {
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await this.GetCollection<UserViewModel>("users");
            return users;
        }

        public async Task<UserViewModel> GetById(string id)
        {
            var user = await this.Get<UserViewModel>($"users/{id}");
            return user;
        }

        public async Task<HttpStatusCode> RegisterUser(string userName, string email, string password, string confirmPassword)
        {
            var user = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", email),
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
            });

            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "Account/Register"), user);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> LoginUser(string userName, string password)
        {
            var loginInfo = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("Password", password)
            });

            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "Token"), loginInfo);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserToken>(content);
            if (user.Token == null)
            {
                return HttpStatusCode.BadRequest;
            }

            var userViewModel = new UserViewModel();
            var addedUser = await userViewModel.InsertUserAsync(user);

            return HttpStatusCode.Ok;
        }
    }
}