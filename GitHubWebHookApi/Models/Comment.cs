using System;

namespace GitHubWebHookApi.Models
{
    namespace MYDelegate
    {
        public class User
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Html
        {
            public string href { get; set; }
        }

        public class PullRequest
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Html html { get; set; }
            public PullRequest pull_request { get; set; }
        }

        public class Comment
        {
            public string url { get; set; }
            public int pull_request_review_id { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string diff_hunk { get; set; }
            public string path { get; set; }
            public int position { get; set; }
            public int original_position { get; set; }
            public string commit_id { get; set; }
            public string original_commit_id { get; set; }
            public User user { get; set; }
            public string body { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string html_url { get; set; }
            public string pull_request_url { get; set; }
            public string author_association { get; set; }
            public Links _links { get; set; }
        }
    }

}
