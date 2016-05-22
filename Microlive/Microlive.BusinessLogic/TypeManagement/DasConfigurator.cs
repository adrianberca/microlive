using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microlive.Model;

namespace Microlive.BusinessLogic.TypeManagement
{
    public static class DasConfigurator
    {
        internal static void ConfigureAspNetRoles(IMapperConfiguration config)
        {
            config.CreateMap<AspNetRole, DataLayer.AspNetRole>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetUsers.Configure(aspNetUser => { aspNetUser.AspNetRoles = null; });
                });

            config.CreateMap<DataLayer.AspNetRole, AspNetRole>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetUsers.Configure(aspNetUser => { aspNetUser.AspNetRoles = null; });
                });
        }

        internal static void ConfigureAspNetUsers(IMapperConfiguration config)
        {
            config.CreateMap<AspNetUser, DataLayer.AspNetUser>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetRoles.Configure(aspNetRole => { aspNetRole.AspNetUsers = null; });
                    source.Images.Configure(image => { image.AspNetUser = null; });
                });

            config.CreateMap<DataLayer.AspNetUser, AspNetUser>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetRoles.Configure(aspNetRole => { aspNetRole.AspNetUsers = null; });
                    source.Images.Configure(image => { image.AspNetUser = null; });
                });
        }

        internal static void ConfigureImages(IMapperConfiguration config)
        {
            config.CreateMap<Image, DataLayer.Image>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetUser.Configure(aspNetUser => { aspNetUser.Images = null; });
                    source.Comments.Configure(comment => { comment.Image = null; });
                    source.Tags.Configure(tag => { tag.Image = null; });

                });

            config.CreateMap<DataLayer.Image, Image>()
                .BeforeMap((source, destination) =>
                {
                    source.AspNetUser.Configure(aspNetUser => { aspNetUser.Images = null; });
                    source.Comments.Configure(comment => { comment.Image = null; });
                    source.Tags.Configure(tag => { tag.Image = null;  });
                });
        }

        internal static void ConfigureComments(IMapperConfiguration config)
        {
            config.CreateMap<Comment, DataLayer.Comment>()
               .BeforeMap((source, destination) =>
               {
                   source.Image.Configure(image => { image.Comments = null; });
                   source.Tags.Configure(tag => { tag.Comment = null; });

               });

            config.CreateMap<DataLayer.Comment, Comment>()
                .BeforeMap((source, destination) =>
                {
                    source.Image.Configure(image => { image.Comments = null; });
                    source.Tags.Configure(tag => { tag.Comment = null; });
                });
        }

        internal static void ConfigureTags(IMapperConfiguration config)
        {
            config.CreateMap<Tag, DataLayer.Tag>()
               .BeforeMap((source, destination) =>
               {
                   source.Comment.Configure(comment => { comment.Tags = null; });
                   source.Image.Configure(image => { image.Comments = null; });
               });

            config.CreateMap<DataLayer.Tag, Tag>()
                .BeforeMap((source, destination) =>
                {
                    source.Comment.Configure(comment => { comment.Tags = null; });
                    source.Image.Configure(image => { image.Comments = null; });
                });
        }
        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}