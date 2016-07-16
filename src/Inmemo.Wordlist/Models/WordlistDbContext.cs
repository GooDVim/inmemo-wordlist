using Microsoft.EntityFrameworkCore;

namespace Inmemo.Wordlist.Models
{
    public class WordlistDbContext : DbContext
    {
        public WordlistDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
    }
}