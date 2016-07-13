using System;
using System.Collections.Generic;
using System.Linq;
using Inmemo.Wordlist.Models;

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

        public Word GetById(int id)
        {
            return _context.Words.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Word> GetByName(string name)
        {
            return _context.Words.Where(w => w.Name.Contains(name));
        }

        public Word GetByRank(int rank)
        {
            return _context.Words.FirstOrDefault(w => w.Rank == rank);
        }

        public void Remove(Word word)
        {
            _context.Remove(word);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}