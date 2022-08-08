using AutoMapper;
using Way2DevBootcamp.Application.Categorias.ViewModels;
using Way2DevBootcamp.Application.Produtos.Commands;
using Way2DevBootcamp.Application.Produtos.ViewModels;
using Way2DevBootcamp.Application.Vendas.Commands;
using Way2DevBootcamp.Application.Vendas.ViewModels;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Utils;
using Way2DevBootcamp.Identity.Results;

namespace Way2DevBootcamp.API.AutoMapper;
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Categoria, CategoriaViewModel>();

        CreateMap<CreateProdutoCommand, Produto>();
        CreateMap<UpdateProdutoCommand, Produto>();
        CreateMap<Produto, ProdutoViewModel>();

        CreateMap<Venda, VendaViewModel>()
            .ForMember(viewModel => viewModel.StatusPedido, opt => opt.MapFrom(venda => EnumHelper.GetDescriptionFromEnumValue(venda.StatusPedido)));

        CreateMap<CreateVendaItemCommand, VendaItem>();
        CreateMap<VendaItem, VendaItemViewModel>();

        CreateMap<LoginResult, LoginViewModel>();
    }
}