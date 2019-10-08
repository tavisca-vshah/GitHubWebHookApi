using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using GitHubWebHookApi.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace GitHubWebHookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubWebHookController : ControllerBase
    {
        // GET: api/GitHubWebHook
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GitHubWebHook/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GitHubWebHook
        [HttpPost]
        public void Post(GitHubPayLoad payload)
        {
            string pullCommentUrl = payload.Pull_request.Review_comments_url;
            ProcessWebHookPayloadAsync(pullCommentUrl).Wait();
            
        }

        private async Task ProcessWebHookPayloadAsync(string pullCommentUrl)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            var token = "af87ff7a081c09c98577eb8e1da658802d9d10b1";
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            var response = await client.GetAsync("repos/tavisca-vshah/hello/pulls/1/comments");
            string data = "";
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<IEnumerable<CommentPayload>>(responseString).ToList<CommentPayload>();
                comments.ForEach(c => data += c.User.Login + "\n" + c.Body + "\n");
                data += $"Total Comments: {comments.Count}\n\n";
            }
            else
            {
                data = $"Error In Fetching Data fro api call {response.ReasonPhrase}";
                data += $"Total Comments: 0\n\n";
            }

            System.IO.File.WriteAllText(@"C:\Users\vshah\Desktop\sampleWebhook\GitHubWebHookApi\GitHubWebHookApi\response.txt", data);
        }

        // PUT: api/GitHubWebHook/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
