using System.Collections.Generic;
using System.Threading.Tasks;
using Inmemo.Wordlist.Models;

namespace Inmemo.Wordlist.Services
{
    public interface IWordRepository
    {
        Task AddAsync(Word word);
        Task<Word> GetByIdAsync(int id);
        Task<List<Word>> GetByNameAsync(string name);
        Task<List<Word>> SearchByNameAsync(string name);
        Task<Word> GetByRankAsync(int rank);
        Task RemoveAsync(Word word);
    }
}