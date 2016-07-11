using System.Collections.Generic;
using Inmemo.Wordlist.Models;

namespace Inmemo.Wordlist.Services
{
    public interface IWordRepository
    {
        void Add(Word word);
        Word GetById(int id);
        IEnumerable<Word> GetByName(string name);
        Word GetByRank(int rank);
        void Save();
    }
}