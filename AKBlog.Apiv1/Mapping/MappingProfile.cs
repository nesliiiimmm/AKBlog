using AKBlog.Apiv1.DTO;
using AKBlog.Core.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Category, CategoryDTO>();
            CreateMap<Comments, CommentsDTO>();
            CreateMap<Tags, TagsDTO>();
            CreateMap<Posts, PostsDTO>();
            CreateMap<User, UserDTO>();

            // Resource to Domain
            CreateMap<CategoryDTO, Category>();
            CreateMap<CommentsDTO, Comments>();
            CreateMap<TagsDTO, Tags>();
            CreateMap<PostsDTO, Posts>();
            CreateMap<UserDTO, User>();

            CreateMap<SaveCategoryDTO, Category>();
            CreateMap<SaveCommentsDTO, Comments>();
            CreateMap<SaveTagsDTO, Tags>();
            CreateMap<SavePostsDTO, Posts>();
            CreateMap<SaveUserDTO, User>();
        }
    }
}
