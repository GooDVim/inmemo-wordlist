using AutoMapper;
using Inmemo.Wordlist.Models;
using Inmemo.Wordlist.ViewModels;

namespace Inmemo.Wordlist
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Word, WordViewModel>();
        }
    }
}