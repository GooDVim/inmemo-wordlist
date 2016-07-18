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

        public Task AddAsync(Word word)
        {
            _context.Add(word);
            return _context.SaveChangesAsync();
        }

        public Task<Word> GetByIdAsync(int id)
        {
            return _context.Words.FirstOrDefaultAsync(w => w.Id == id);
        }
        
        public Task<List<Word>> GetByNameAsync(string name)
        {
            return _context.Words.Where(w => w.Name == name.ToLower()).OrderBy(w => w.Rank).ToListAsync();
        }
        public Task<List<Word>> SearchByNameAsync(string name)
        {
            return _context.Words.Where(w => w.Name.Contains(name)).OrderBy(w => w.Rank).ToListAsync();
        }

        public Task<Word> GetByRankAsync(int rank)
        {
            return _context.Words.FirstOrDefaultAsync(w => w.Rank == rank);
        }

        public Task RemoveAsync(Word word)
        {
            _context.Remove(word);
            return _context.SaveChangesAsync();
        }
    }
}