namespace AbpLearning.Web.Core.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Abp.Json;
    using System;

    [Route("api/[controller]/[action]")]
    public class ThirdOAuthController : AbpLearningControllerBase
    {
        [HttpGet]
        public async Task OAuth2ForGithub(string code)
        {
            var http = new HttpClient();

            var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("client_id", "9381792e7265342f63e8"),
                    new KeyValuePair<string, string>("client_secret","9098720cabe90cdb78d83876214c532767728a64")
                };
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://github.com/login/oauth/access_token");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new FormUrlEncodedContent(body);
            var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            // {"access_token":"","token_type":"","scope":""}
            var result = await response.Content.ReadAsStringAsync();

            var obj = JsonExtensions.FromJsonString<dynamic>(result);

            request.Dispose();

            var request2 = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user" + "?access_token=" + Uri.EscapeDataString((string)obj.access_token));
            request2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response2 = await http.SendAsync(request2);
            response2.EnsureSuccessStatusCode();

            /*{
            "login": "Maple512",
              "id": 34236341,
              "node_id": "MDQ6VXNlcjM0MjM2MzQx",
              "avatar_url": "https://avatars2.githubusercontent.com/u/34236341?v=4",
              "gravatar_id": "",
              "url": "https://api.github.com/users/Maple512",
              "html_url": "https://github.com/Maple512",
              "followers_url": "https://api.github.com/users/Maple512/followers",
              "following_url": "https://api.github.com/users/Maple512/following{/other_user}",
              "gists_url": "https://api.github.com/users/Maple512/gists{/gist_id}",
              "starred_url": "https://api.github.com/users/Maple512/starred{/owner}{/repo}",
              "subscriptions_url": "https://api.github.com/users/Maple512/subscriptions",
              "organizations_url": "https://api.github.com/users/Maple512/orgs",
              "repos_url": "https://api.github.com/users/Maple512/repos",
              "events_url": "https://api.github.com/users/Maple512/events{/privacy}",
              "received_events_url": "https://api.github.com/users/Maple512/received_events",
              "type": "User",
              "site_admin": false,
              "name": null,
              "company": null,
              "blog": "",
              "location": null,
              "email": null,
            }*/
            result = await response2.Content.ReadAsStringAsync();
        }
    }
}
