using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inmemo.Wordlist.Controllers
{
    [Route("word/[action]")]
    public class WordController : Controller
    {
        private IWordRepository _repository;
        public WordController(IWordRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Seed()
        {
            _repository.Add(new Word
            {
                Name = "retrieve",
                PartOfSpeech = PartOfSpeech.Verb,
                Rank = 5000,
                Total = 6275,
                Spoken = 335,
                Fiction = 1947,
                Magazine = 1235,
                Newspaper = 657,
                Academic = 2101
            });
            _repository.Save();
            return Json("test");
        }

        [Route("{name}")]
        public JsonResult Name(string name)
        {
            return Json(_repository.GetByName(name.ToLower()));
        }

        [Route("{rank:int}")]
        public JsonResult Rank(int rank)
        {
            return Json(_repository.GetByRank(rank));
        }

        [Route("{id:int}")]
        public JsonResult Id(int id)
        {
            return Json(_repository.GetById(id));
        }
    }
}