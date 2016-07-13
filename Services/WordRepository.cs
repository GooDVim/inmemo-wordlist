using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmemo.Wordlist.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmemo.Wordlist.Services
{
    public class WordRepository : IWordRepository
    {
        private WordlistDbContext _context;
        public WordRepository(WordlistDbContext context)
        {
            _context = context;
        }

        public void Add(Word word)
        {
            _context.Add(word);
        }

        public Task<Word> GetByIdAsync(int id)
        {
            return _context.Words.FirstOrDefaultAsync(w => w.Id == id);
        }

        public Task<List<Word>> GetByNameAsync(string name)
        {
            return _context.Words.Where(w => w.Name.Contains(name)).ToListAsync();
        }

        public Task<Word> GetByRankAsync(int rank)
        {
            return _context.Words.FirstOrDefaultAsync(w => w.Rank == rank);
        }

        public void Remove(Word word)
        {
            _context.Remove(word);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}