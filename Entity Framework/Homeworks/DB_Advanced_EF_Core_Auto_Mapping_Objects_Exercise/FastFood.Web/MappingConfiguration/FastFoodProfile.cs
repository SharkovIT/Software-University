namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(src => src.Type, dest => dest.MapFrom(src => src.OrderType));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(src => src.OrderId, dest => dest.MapFrom(src => src.Id))
                .ForMember(src => src.Employee, dest => dest.MapFrom(src => src.Employee.Name))
                .ForMember(src => src.DateTime, dest => dest.MapFrom(src => src.DateTime.ToString("g")))
                .ForMember(src => src.OrderType, dest => dest.MapFrom(src => src.Type.ToString()));

            //Items
            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(src => src.Category, dest => dest.MapFrom(src => src.Category.Name));

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(src => src.CategoryName, dest => dest.MapFrom(src => src.Name));

            //Employees
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(src => src.PositionName, dest => dest.MapFrom(src => src.Name));

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(src => src.Position, dest => dest.MapFrom(src => src.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();
        }
    }
}
