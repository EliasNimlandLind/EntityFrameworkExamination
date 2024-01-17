using EFIntro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExamination
{
    public class ObjectReader
    {
        public BloggingContext BloggingContext { get; set; }

        private static string[] GetBlogInformation()
        {
            return File.ReadAllLines("../../../blog.csv");
        }

        private static string[] GetUserInformation()
        {
            return File.ReadAllLines("../../../user.csv");
        }

        private static string[] GetPostInformation()
        {
            return File.ReadAllLines("../../../post.csv");
        }

        public void AddBlogs()
        {
            List<int> blogIds1 = new List<int>();
            List<int> blogIds2 = new List<int>();

            foreach (string blogAsString in GetBlogInformation())
            {
                string[] blogAttributes = blogAsString.Split(',');
                int postIds = int.Parse(blogAttributes[3]);
                int blogid = int.Parse(blogAttributes[0]);
                if (blogid == 1)
                {
                    blogIds1.Add(postIds);
                }
                else
                {
                    blogIds2.Add(postIds);
                }
            }

            string currentURL = string.Empty;
            int count = 0;
            foreach (string blogAsString in GetBlogInformation())
            {
                string[] logAttributes = blogAsString.Split(',');
                string uRLFromFile = logAttributes[1];
                string name = logAttributes[2];
                int postId = int.Parse(logAttributes[3]);

                if (currentURL != uRLFromFile)
                {
                    if (count == 0)
                    {
                        BloggingContext.Blogs.Add(new Blog
                        {
                            URL = uRLFromFile,
                            Name = name,
                            PostIds = blogIds1
                        });
                        count++;
                    }
                    else
                    {
                        BloggingContext.Blogs.Add(new Blog
                        {
                            URL = uRLFromFile,
                            Name = name,
                            PostIds = blogIds2
                        });
                        break;
                    }
                }
                currentURL = uRLFromFile;
            }
        }

        public void AddUsers()
        {
            List<int> userIds1 = new List<int>();
            List<int> userIds2 = new List<int>();
            foreach (string userAsString in GetUserInformation())
            {
                string[] userLine = userAsString.Split(',');
                int postId = int.Parse(userLine[3]);
                int userId = int.Parse(userLine[0]);
                if (userId == 1)
                {
                    userIds1.Add(postId);
                }
                else
                {
                    userIds2.Add(postId);
                }
            }

            string currentUsername = string.Empty;
            int count = 0;
            foreach (string userAsString in GetUserInformation())
            {
                string[] userAttributes = userAsString.Split(',');
                int userId = int.Parse(userAttributes[0]);
                string usernameFromFile = userAttributes[1];
                string password = userAttributes[2];
                int postId = int.Parse(userAttributes[3]);

                if (currentUsername != usernameFromFile)
                {
                    if (count == 0)
                    {
                        BloggingContext.Users.Add(new User
                        {
                            Id = userId,
                            Username = usernameFromFile,
                            Password = password,
                            PostIds = userIds1
                        });
                        count++;
                    }
                    else
                    {
                        BloggingContext.Users.Add(new User
                        {
                            Id = userId,
                            Username = usernameFromFile,
                            Password = password,
                            PostIds = userIds2
                        });
                        break;
                    }
                }
                currentUsername = usernameFromFile;
            }
        }

        public void AddPosts()
        {
            foreach (string postAsString in GetPostInformation())
            {
                string[] postAttributes = postAsString.Split(',');
                int postId = int.Parse(postAttributes[0]);
                string title = postAttributes[1];
                string content = postAttributes[2];
                DateOnly publishedOn = DateOnly.Parse(postAttributes[3]);
                int blogId = int.Parse(postAttributes[4]);
                int userId = int.Parse(postAttributes[5]);

                BloggingContext.Posts.Add(new Post
                {
                    Id = postId,
                    Title = title,
                    Content = content,
                    PublishedOn = publishedOn,
                    BlogId = blogId,
                    UserId = userId
                });
            }
        }

        public override string  ToString()
        {
            string treeRepresentation = string.Empty;

            List<Blog> blogs = BloggingContext.Blogs.ToList();
            treeRepresentation += "Blogs";
            foreach (Blog blog in blogs)
            {
                treeRepresentation += $"Blog id: {blog.Id}\n" +
                                                    $"      Url: {blog.URL}" +
                                                    $"      Name: {blog.Name}\n\n";
            }

            List<User> users = BloggingContext.Users.ToList();
            treeRepresentation += "Users:\n";
            foreach (User user in users)
            {
                treeRepresentation += $"User Id: {user.Id}\n" +
                                                    $"      Username: {user.Username}\n" +
                                                    $"      Password: {user.Password}\n\n";
            }

            List<Post> posts = BloggingContext.Posts.ToList();
            treeRepresentation += "Posts:\n";
            foreach (Post post in posts)
            {
                treeRepresentation += $"Post id: {post.Id}\n " +
                                                     $"     Title: {post.Title}\n " +
                                                     $"     Content: {post.Content}\n " +
                                                     $"     Published on: {post.PublishedOn}\n " +
                                                     $"     Blog id: {post.BlogId}\n " +
                                                     $"     User id: {post.UserId}\n";
            }
            return treeRepresentation;
        }
    }
}
