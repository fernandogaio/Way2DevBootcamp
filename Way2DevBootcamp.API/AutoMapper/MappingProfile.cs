using AutoMapper;
using Way2DevBootcamp.API.ViewModels;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.API.AutoMapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<CategoriaViewModelInput, Categoria>();
            CreateMap<Categoria, CategoriaViewModelOutput>();
            CreateMap<ProdutoViewModelInput, Produto>();
            CreateMap<Produto, ProdutoViewModelOutput>();
        }
    }
}
