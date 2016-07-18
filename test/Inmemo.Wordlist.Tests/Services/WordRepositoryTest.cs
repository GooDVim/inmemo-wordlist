using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmemo.Wordlist.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Inmemo.Wordlist.Services
{
    public class WordRepositoryTest
    {
        [Fact]
        public async Task AddAsyncShouldAddWord()
        {
            // Arrange
            var testWord = new Word { Id = 100500, Name = "test", PartOfSpeech = PartOfSpeech.Noun, Rank = 10001 };
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            await repository.AddAsync(testWord);

            // Assert
            Assert.NotNull(context.Words.FirstOrDefault(w => w.Id == 100500));
            Assert.Equal(5, context.Words.Count());
        }

        [Fact]
        public async Task RemoveAsyncShouldRemoveWord()
        {
            // Arrange
            var context = CreateAndSeedContext();
            var testWord = context.Words.First(w => w.Id == 851);

            var repository = new WordRepository(context);

            // Act
            await repository.RemoveAsync(testWord);

            // Assert
            Assert.Null(context.Words.FirstOrDefault(w => w.Id == 851));
            Assert.Equal(3, context.Words.Count());
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnWordIfIdExists()
        {
            // Arrange
            var testId = 2378;
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByIdAsync(testId);

            // Assert
            Assert.Equal(2378, result.Id);
            Assert.Equal("lifetime", result.Name);
            Assert.Equal(PartOfSpeech.Noun, result.PartOfSpeech);
            Assert.Equal(2784, result.Rank);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullIfIdDoesNotExist()
        {
            // Arrange
            var testId = 100500;
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByIdAsync(testId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByRankAsyncShouldReturnWordIfRankExists()
        {
            // Arrange
            var testRank = 52;
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByRankAsync(testRank);

            // Assert
            Assert.Equal(647, result.Id);
            Assert.Equal("time", result.Name);
            Assert.Equal(PartOfSpeech.Noun, result.PartOfSpeech);
            Assert.Equal(52, result.Rank);
        }

        [Fact]
        public async Task GetByRankAsyncShouldReturnNullIfRankDoesNotExist()
        {
            // Arrange
            var testRank = 100500;
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByRankAsync(testRank);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByNameAsyncShouldReturnListOfWordsIfNameExists()
        {
            // Arrange
            var testName = "time";
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByNameAsync(testName);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.True(result.All(w => w.Name == testName));
            Assert.True(result.Exists(w => w.Id == 647));
            Assert.True(result.Exists(w => w.Id == 5546));
        }

        [Fact]
        public async Task GetByNameAsyncShouldReturnEmptyListIfNameDoesNotExist()
        {
            // Arrange
            var testName = "nonexistentWord";
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.GetByNameAsync(testName);

            // Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public async Task SearchByNameAsyncShouldReturnListOfWordsIfNameExists()
        {
            // Arrange
            var testName = "time";
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.SearchByNameAsync(testName);

            // Assert
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public async Task SearchByNameAsyncShouldReturnEmptyListIfNameDoestNotExist()
        {
            // Arrange
            var testName = "nonexistentWord";
            var context = CreateAndSeedContext();
            var repository = new WordRepository(context);

            // Act
            var result = await repository.SearchByNameAsync(testName);

            // Assert
            Assert.Equal(0, result.Count);
        }

        private WordlistDbContext CreateAndSeedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WordlistDbContext>();
            optionsBuilder.UseInMemoryDatabase();

            var context = new WordlistDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Words.AddRange(BuildWord());
            context.SaveChanges();
            return context;
        }
        private List<Word> BuildWord()
        {
            var words = new List<Word>
            {
                new Word {Id = 647, Name = "time", PartOfSpeech = PartOfSpeech.Noun, Rank = 52},
                new Word {Id = 851, Name = "sometimes", PartOfSpeech = PartOfSpeech.Adverb, Rank = 445},
                new Word {Id = 2378, Name = "lifetime", PartOfSpeech = PartOfSpeech.Noun, Rank = 2784},
                new Word {Id = 5546, Name = "time", PartOfSpeech = PartOfSpeech.Verb, Rank = 5139}
            };
            return words;
        }
    }
}