﻿using DayChallengeData;
using DayChallengeModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeServices
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text
                //CommentId = model.CommentId

            };

            using (var ctx = new DayChallengeDBContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetAllPosts()
        {
            using (var ctx = new DayChallengeDBContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                       
                          e => new PostListItem
                          {
                              PostId = e.PostId,
                              Title = e.Title,
                              Text = e.Text,
                              //CommentId = e.CommentId
                              
                          }
                    );

                return query.ToArray();
            }
        }
    }

}
