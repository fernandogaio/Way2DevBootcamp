using AutoMapper;
using Way2DevBootcamp.Application.Commands;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Utils;

namespace Way2DevBootcamp.API.AutoMapper;
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CategoriaViewModelInput, Categoria>();
        CreateMap<Categoria, CategoriaViewModelOutput>();

        CreateMap<CreateProdutoCommand, Produto>();
        CreateMap<UpdateProdutoCommand, Produto>();
        CreateMap<Produto, ProdutoViewModel>();

        CreateMap<Venda, VendaViewModel>()
            .ForMember(viewModel => viewModel.StatusPedido, opt => opt.MapFrom(venda => EnumHelper.GetDescriptionFromEnumValue(venda.StatusPedido)));
        CreateMap<VendaItem, VendaItemViewModel>();
    }
}