using System.Threading.Tasks;
using Inmemo.Wordlist.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Inmemo.Wordlist.ViewModels;
using System.Collections.Generic;

namespace Inmemo.Wordlist.Controllers
{
    [Route("word/[action]")]
    public class WordController : Controller
    {
        private IWordRepository _repository;
        private IMapper _mapper { get; set; }

        public WordController(IWordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [Route("{name}")]
        public async Task<JsonResult> Name(string name)
        {
            var words = await _repository.GetByNameAsync(name.ToLower());
            return Json(_mapper.Map<List<WordViewModel>>(words));
        }

        [Route("{rank:int}")]
        public async Task<JsonResult> Rank(int rank)
        {
            var word = await _repository.GetByRankAsync(rank);
            return Json(_mapper.Map<WordViewModel>(word));
        }

        [Route("{id:int}")]
        public async Task<JsonResult> Id(int id)
        {
            var word = await _repository.GetByIdAsync(id);
            return Json(_mapper.Map<WordViewModel>(word));
        }
    }
}