using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.ViewModels;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using AutoMapper;

namespace Inmemo.Wordlist.Controllers
{
    public class WordControllerTest
    {
        [Fact]
        public async Task NameShouldReturnsWordList()
        {
            // Arrange
            var testWordName = "time";
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByNameAsync(testWordName)).Returns(Task.FromResult(GetWordList()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Name(testWordName);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<WordViewModel>>(jsonResult.Value);
            var word = returnValue.FirstOrDefault();
            Assert.Equal(647, word.Id);
            Assert.Equal("time", word.Name);
            Assert.Equal(52, word.Rank);
            Assert.Equal("noun", word.PartOfSpeech);
        }

        [Fact]
        public async Task NameShouldReturnsEmptyListWhenRepositoryReturnsEmptyList()
        {
            // Arrange
            var testWordName = "nonexistent_word";
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByNameAsync(testWordName)).Returns(Task.FromResult(GetEmptyWordList()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Name(testWordName);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<WordViewModel>>(jsonResult.Value);
            Assert.Equal(0, returnValue.Count());
        }

        [Fact]
        public async Task SearchShouldReturnsWordList()
        {
            // Arrange
            var testQuery = "time";
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.SearchByNameAsync(testQuery)).Returns(Task.FromResult(GetWordList()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Search(testQuery);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<WordViewModel>>(jsonResult.Value);
            var word = returnValue.FirstOrDefault();
            Assert.Equal(647, word.Id);
            Assert.Equal("time", word.Name);
            Assert.Equal(52, word.Rank);
            Assert.Equal("noun", word.PartOfSpeech);
        }

        [Fact]
        public async Task SearchShouldReturnsEmptyListWhenRepositoryReturnsEmptyList()
        {
            // Arrange
            var testQuery = "nonexistent_word";
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.SearchByNameAsync(testQuery)).Returns(Task.FromResult(GetEmptyWordList()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Search(testQuery);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnValue = Assert.IsType<List<WordViewModel>>(jsonResult.Value);
            Assert.Equal(0, returnValue.Count());
        }

        [Fact]
        public async Task IdShouldReturnsWord()
        {
            // Arrange
            var testWordId = 647;
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByIdAsync(testWordId)).Returns(Task.FromResult(GetWord()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Id(testWordId);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var word = Assert.IsType<WordViewModel>(jsonResult.Value);
            Assert.Equal(647, word.Id);
            Assert.Equal("time", word.Name);
            Assert.Equal(52, word.Rank);
            Assert.Equal("noun", word.PartOfSpeech);
        }

        [Fact]
        public async Task IdShouldReturnsNotFoundWhenRepositoryReturnsNull()
        {
            // Arrange
            var testWordId = 100500;
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByIdAsync(testWordId)).Returns(Task.FromResult((Word)null));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Id(testWordId);

            // Assert
            var jsonResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task RankShouldReturnsWord()
        {
            // Arrange
            var testWordRank = 52;
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByRankAsync(testWordRank)).Returns(Task.FromResult(GetWord()));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Rank(testWordRank);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var word = Assert.IsType<WordViewModel>(jsonResult.Value);
            Assert.Equal(647, word.Id);
            Assert.Equal("time", word.Name);
            Assert.Equal(52, word.Rank);
            Assert.Equal("noun", word.PartOfSpeech);
        }

        [Fact]
        public async Task RankShouldReturnsNotFoundWhenRepositoryReturnsNull()
        {
            // Arrange
            var testWordRank = 100500;
            var mockWordRepository = new Mock<IWordRepository>();
            mockWordRepository.Setup(repo => repo.GetByRankAsync(testWordRank)).Returns(Task.FromResult((Word)null));
            var mockMapper = CreateMockMapper();
            var controller = new WordController(mockWordRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.Id(testWordRank);

            // Assert
            var jsonResult = Assert.IsType<NotFoundResult>(result);
        }

        private Mock<IMapper> CreateMockMapper()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<WordViewModel>(It.IsAny<Word>())).Returns((Word w) => GetWordViewModel(w));
            mockMapper.Setup(mapper => mapper.Map<List<WordViewModel>>(It.IsAny<List<Word>>())).Returns((List<Word> wl) => GetWordViewModelList(wl));
            return mockMapper;
        }

        private Word GetWord()
        {
            return new Word
            {
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
            };
        }

        private List<Word> GetWordList()
        {
            return new List<Word>{
                GetWord()
            };
        }

        private List<Word> GetEmptyWordList()
        {
            return new List<Word>();
        }

        private WordViewModel GetWordViewModel(Word word)
        {
            return new WordViewModel { Id = word.Id, Name = word.Name, Rank = word.Rank, PartOfSpeech = word.PartOfSpeech.ToString().ToLower() };
        }

        private List<WordViewModel> GetWordViewModelList(List<Word> words)
        {
            return words.Select(w => new WordViewModel { Id = w.Id, Name = w.Name, Rank = w.Rank, PartOfSpeech = w.PartOfSpeech.ToString().ToLower() }).ToList();
        }
    }
}