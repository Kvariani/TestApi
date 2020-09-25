using AutoMapper;
using PersonDirectory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Person, BasePerson>().ForMember(x => x.ID, opt => opt.Ignore());
            CreateMap<BasePerson, Person>().ForMember(x => x.ID, opt => opt.Ignore());
        }
    }
}