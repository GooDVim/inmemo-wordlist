using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmemo.Wordlist.Controllers;
using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.ViewModels;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using AutoMapper;

namespace Inmemo.Wordlist.Tests.UnitTests
{
    public class WordControllerTests
    {
        private List<Word> GetWords()
        {
            return new List<Word>{
                new Word {
                    Id = 647,
                    Name = "time",
                    Rank = 52,
                    PartOfSpeech = PartOfSpeech.Noun,
                    Spoken = 196659,
                    Fiction = 172054,
                    Magazine = 178141,
                    Newspaper = 156965,
                    Academic = 129155,
                    Total = 832974
                }
            };
        }

        private List<WordViewModel> GetWordViewModelList(){
            return new List<WordViewModel>{
                new WordViewModel{
                    Id = 647,
                    Name = "time",
                    Rank = 52
                }
            };
        }

        [Fact]
        public async Task Name_ReturnsWordList()
        {
            // Arrange
            var testName = "time";
            var wordList = GetWords();
            var mockRepo = new Mock<IWordRepository>();
            mockRepo.Setup(repo => repo.GetByNameAsync(testName)).Returns(Task.FromResult(wordList));
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<List<WordViewModel>>(wordList)).Returns(GetWordViewModelList());
            var controller = new WordController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.Name(testName);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<WordViewModel>>(jsonResult.Value);
            var word = returnValue.FirstOrDefault();
            Assert.Equal(647, word.Id);
            Assert.Equal("time", word.Name);
            Assert.Equal(52, word.Rank);
        }
    }
}