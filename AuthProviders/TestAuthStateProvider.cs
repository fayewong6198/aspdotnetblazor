
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using aspnetblazor.States;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
namespace aspnetblazor.AuthProviders
{
    public class TestAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly NavigationManager navigationManager;
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;
        public TestAuthStateProvider(ILocalStorageService localStorageService, NavigationManager navigationManager, IConfiguration configuration, HttpClient httpClient)
        {
            this.localStorageService = localStorageService;
            this.navigationManager = navigationManager;
            this.configuration = configuration;
            this.httpClient = httpClient;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await this.localStorageService.GetItemAsync<string>("token");

            List<Claim> claims;

            if (token == "" || token == null)
            {
                this.navigationManager.NavigateTo("/login");
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));

            }
            else
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("token", token);

                try
                {
                    var res = await client.GetFromJsonAsync<User>($"{this.configuration["API"]}/api/authorization/getme");

                    ApplicationUser.setAvatar(res.Avatar);
                    ApplicationUser.setUserName(res.UserName);
                    ApplicationUser.setRole(res.Role);
                    ApplicationUser.setEmail(res.Email);
                    ApplicationUser.setLogin();

                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, res.UserName),
                        new Claim("Avatar", "https://kenh14cdn.com/thumb_w/660/2020/10/17/1-0952-16029340185651467234759.jpg"),
                        new Claim(ClaimTypes.Role, "Administrator")
                    };
                    var authorized = new ClaimsIdentity(claims, "testAuthType");
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(authorized)));
                }
                catch (Exception e)
                {
                    this.navigationManager.NavigateTo("/login");
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
                }

            }


        }



        private class User
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public string Avatar { get; set; }


        }
    }
}