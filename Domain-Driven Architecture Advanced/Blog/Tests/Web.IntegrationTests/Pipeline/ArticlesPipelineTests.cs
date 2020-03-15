﻿using System.Linq;
using Blog.Application.Articles.Commands.ChangeVisibility;
using Blog.Infrastructure.Persistence;
using Blog.Web.Controllers;
using MyTested.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace Blog.Web.IntegrationTests.Pipeline
{
    public class ArticlesPipelineTests
    {
        [Theory]
        [InlineData(1)]
        public void ChangeVisibilityShouldBeRoutedCorrectlyAndShouldReturnNoContent(int id) => 
            MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Put)
                    .WithLocation("api/Articles/ChangeVisibility")
                    .WithJsonBody(new {Id = id}))
                .To<ArticlesController>(c => c
                    .ChangeVisibility(new ChangeArticleVisibilityCommand {Id = id}))
                .Which(controller => controller
                    .WithData(data => data
                        .WithEntities<BlogDbContext>(TestData.Articles)))
                .ShouldHave()
                .Data(data => data
                    .WithEntities<BlogDbContext>(entities => entities
                        .Articles
                        .FirstOrDefault(a =>a.Id == id && a.IsPublic)
                        .ShouldNotBeNull()))
                .AndAlso()
                .ShouldReturn()
                .NoContent();
    }
}
