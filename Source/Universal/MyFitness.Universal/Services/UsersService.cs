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
        private readonly UserViewModel userViewModel;

        public UsersService()
            : base()
        {
            this.userViewModel = new UserViewModel();
        }

        public UsersService(HttpClient httpClient, UserViewModel userViewModel)
           : base(httpClient)
        {
            this.userViewModel = userViewModel;
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

        public async void RegisterUser(string UserName, string Email, string password, string confirmPassword)
        {
            var user = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", Email),
                new KeyValuePair<string, string>("UserName", UserName),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
            });

            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "Account/Register"), user);
        }

        public async void LoginUser(string UserName, string password)
        {
            UserName = "PROBA";
            password = "123456";
            var loginInfo = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("UserName", UserName),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("Password", password)
            });

            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "Token"), loginInfo);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserToken>(content);
            var added = await userViewModel.InsertUserAsync(user);
        }
    }
}