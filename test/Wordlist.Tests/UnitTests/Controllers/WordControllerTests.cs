using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmemo.Wordlist.Controllers;
using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Inmemo.Wordlist.Tests.UnitTests
{
    public class WordControllerTests
    {
        private List<Word> GetWords()
        {
            return new List<Word>{
                new Word {
                    Name = "time"
                }
            };
        }

        [Fact]
        public async Task Name_ReturnsWordList()
        {
            // Arrange
            var testName = "time";
            var mockRepo = new Mock<IWordRepository>();
            mockRepo.Setup(repo => repo.GetByNameAsync(testName)).Returns(Task.FromResult(GetWords()));
            var controller = new WordController(mockRepo.Object);

            // Act
            var result = await controller.Name(testName);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<Word>>(jsonResult.Value);
            var word = returnValue.FirstOrDefault();
            Assert.Equal("time", word.Name);
        }
    }
}