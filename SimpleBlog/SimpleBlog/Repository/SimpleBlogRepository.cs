using Microsoft.WindowsAzure.MobileServices;
using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SimpleBlog.Services
{
    public class SimpleBlogRepository
    {
        MobileServiceClient _client;
        IMobileServiceTable<Blog> _blogTable;

        public SimpleBlogRepository()
        {
            this._client = new MobileServiceClient("https://kh-simpleblog.azurewebsites.net");
            this._blogTable = _client.GetTable<Blog>();
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            
            var blogs = await _blogTable.ToListAsync();

            if (blogs.Count == 1)
            {
                await InsertNewBlogs();
                blogs = await _blogTable.ToListAsync();
            }

            return blogs; 
        }

        private async Task InsertNewBlogs()
        {
            await InsertNewBlog(new Blog
            {
                BlogDescription = "olestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel.",
                BlogTitle = "Blog 1",
                CreatedDate = DateTime.Now,
                CreatedBy = "Ryan Nguyen"
            });

            await InsertNewBlog(new Blog
            {
                BlogDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam a sollicitudin erat. Vestibulum dapibus sagittis risus, sit amet molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
                BlogTitle = "Blog 2",
                CreatedDate = new DateTime(2017, 12, 30),
                CreatedBy = "Adam Costenbader"
            });

            await InsertNewBlog(new Blog
            {
                BlogDescription = "Etiam a sollicitudin erat. Vestibulum dapibus sagittis risus, sit amet molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
                BlogTitle = "Blog 3",
                CreatedDate = new DateTime(2017, 11, 30),
                CreatedBy = "Rusty Divine"
            });

            await InsertNewBlog(new Blog
            {
                BlogDescription = "molestie lectus rhoncus non. Ut eget metus neque. Cras laoreet quam ligula, in ultricies enim lobortis vitae. Proin sed justo vel quam luctus bibendum. Praesent gravida vehicula nunc, eu aliquet elit vestibulum non. Aliquam aliquam fringilla nunc, eget tincidunt dui finibus vel. Ut fermentum viverra justo, a vehicula dui dignissim non. Aenean posuere vestibulum felis, eu fringilla nulla. Nam interdum enim nec risus cursus tempus. Integer vestibulum hendrerit metus, a venenatis justo molestie at. Vestibulum nec libero in velit pulvinar pretium non in enim. Nulla pulvinar auctor dolor, eu laoreet quam vehicula nec. Cras vehicula fringilla massa, vitae molestie lectus dignissim sed. Integer suscipit auctor est, eu bibendum turpis aliquam vitae.",
                BlogTitle = "Blog 4",
                CreatedDate = new DateTime(2017, 10, 30),
                CreatedBy = "Linh Nguyen"
            });
        }

        private async Task InsertNewBlog(Blog blog)
        {
            await _blogTable.InsertAsync(blog);
        }
    }
}
