using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPosts.Implementation.Model;
using UserPosts.Implementation.Repository;
using UserPosts.Implementation.Services;

namespace UserPosts.Site.Tests
{
    [TestFixture]
    public class UserPostsServiceTests
    {
        [Test]
        public void UserPostsService_HasCorrectPostCountGivenAUserAndPostCollection()
        {
            Mock<IUserPostsRepository> userPostsRepo = new Mock<IUserPostsRepository>();

            userPostsRepo.Setup(m => m.GetAllUsers()).ReturnsAsync(new List<UserRaw>() {

                new UserRaw()
                {
                    Name = "Giles",
                    Id = 1,
                    Address = new Address(),
                    Company = new Company()
                },
                new UserRaw()
                {
                    Name = "Joseph",
                    Id = 2,
                    Address = new Address(),
                    Company = new Company()
                }
            });

            userPostsRepo.Setup(m => m.GetAllPosts()).ReturnsAsync(new List<PostRaw>() {

                new PostRaw()
                {
                    UserId = 1,
                    Title = "asd",
                    Body = "fgdfgfdgfd"
                },
                new PostRaw()
                {
                    UserId = 1,
                    Title = "asjghjghjd",
                    Body = "fgdfghgjgjghjghjghfdgfd"
                },
                new PostRaw()
                {
                    UserId = 1,
                    Title = "title",
                    Body = "body"
                },
            });

            var service = new UserPostsService(userPostsRepo.Object);
            var actual = service.GetUserAndPostCounts().Result;
            var expectedCount = 3;

            // mocking the data call to get 2 users and posts, check that the service assigns the correct number of
            // posts to the user with userId 1
            Assert.AreEqual(expectedCount, actual.Where(o => (o.User.Id == 1)).First().Posts.Count());            
        }
    }
}
