using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using WoodWorkshop.Data.Models;
using WoodWorkshop.Data.Repositories;
using WoodWorkshop.Domain.Models;

namespace WoodWorkshop.Domain
{
    public class WoodWorkshopService
    {
        private List <string> NumbersBlackList { get; set; }
        private readonly WoodWorkshopRepository _woodWorkshopRepository;
        private readonly IMapper _mapper;

        public WoodWorkshopService()
        {
            _woodWorkshopRepository = new WoodWorkshopRepository();

            NumbersBlackList = new List<string>();
            GetBlackList();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap< WoodFurnitureModel, WoodFurniture>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        private void GetBlackList()
        {
            FileStream file = new FileStream("blacklist.txt",  FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            
            while(!reader.EndOfStream)
            {
                NumbersBlackList.Add(reader.ReadLine());
            }
                 
        }

        public void CreateFurnitureRequest(WoodFurnitureModel model)
        {
            if (NumbersBlackList.Any(phone => phone.Equals(model.PhoneNumber)))
                throw new System.Exception("This phone number in blacklist");

            var woodFurniture = _mapper.Map<WoodFurniture>(model);

            _woodWorkshopRepository.Create(woodFurniture);

        }
    }
}
