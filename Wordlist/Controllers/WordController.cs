using System.Threading.Tasks;
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


        [Route("{name}")]
        public async Task<JsonResult> Name(string name)
        {
            var words = await _repository.GetByNameAsync(name.ToLower()); 
            return Json(words);
        }

        [Route("{rank:int}")]
        public async Task<JsonResult> Rank(int rank)
        {
            var word = await _repository.GetByRankAsync(rank); 
            return Json(word);
        }

        [Route("{id:int}")]
        public async Task<JsonResult> Id(int id)
        {
            var word = await _repository.GetByIdAsync(id); 
            return Json(word);
        }
    }
}