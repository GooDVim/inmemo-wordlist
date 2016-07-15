using System.Collections.Generic;
using System.Threading.Tasks;
using Inmemo.Wordlist.Models;

namespace Inmemo.Wordlist.Services
{
    public interface IWordRepository
    {
        void Add(Word word);
        Task<Word> GetByIdAsync(int id);
        Task<List<Word>> GetByNameAsync(string name);
        Task<Word> GetByRankAsync(int rank);
        void Remove(Word word);
        Task SaveAsync();
    }
}