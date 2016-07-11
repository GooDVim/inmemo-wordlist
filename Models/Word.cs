using System.ComponentModel.DataAnnotations.Schema;

namespace Inmemo.Wordlist.Models
{
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public int Spoken { get; set; }
        public int Fiction { get; set; }
        public int Magazine { get; set; }
        public int Newspaper { get; set; }
        public int Academic { get; set; }
        public int Total { get; set; }
    }
}