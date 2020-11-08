using System;
using WoodWorkshop.Models.PostModels;
using WoodWorkshop.Domain;
using AutoMapper;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Models.ViewModels;

namespace WoodWorkshop.Controllers
{
    public class WoodFurnitureController
    {
        private readonly WoodWorkshopService _woodWorkshopService;
        private readonly IMapper _mapper;

        public WoodFurnitureController()
        {
            _woodWorkshopService = new WoodWorkshopService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap<CreateWoodFurniturePostModel, WoodFurnitureModel>();
                var map2 = cfg.CreateMap<WoodFurnitureModel, WoodFurnitureViewModel> ();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(CreateWoodFurniturePostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new System.Exception("Invalid FullName");
            if (model.PhoneNumber.Length != 13)
                throw new System.Exception("Invalid Phone Number");
            if (model.FurnitureType.Length == 0)
                throw new System.Exception("Invalid Furniture Type");

            var woodFurnitureModel = _mapper.Map<WoodFurnitureModel>(model);

            _woodWorkshopService.CreateFurnitureRequest(woodFurnitureModel);
        }

        public WoodFurnitureViewModel GetItemById(int id)
        {
            var woodFurnitureModel = _woodWorkshopService.GetItemById(id);

            return _mapper.Map<WoodFurnitureViewModel>(woodFurnitureModel);
        }


    }
}
