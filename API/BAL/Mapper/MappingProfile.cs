using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataModels;
using Models.DTO;

namespace BAL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Add as many of these lines as you need to map your objects
                cfg.CreateMap<Author, AuthorDTO>()
                    .ForMember(c => c.Id, d => d.MapFrom(o => o.Id))
                    .ForMember(c => c.Name, d => d.MapFrom(o => o.Name))
                    .ForMember(c => c.Surname, d => d.MapFrom(o => o.Surname))
                    .ForMember(c => c.Age, d => d.MapFrom(o => o.Age));

                cfg.CreateMap<AuthorDTO, Author>()
                    .ForMember(c => c.Id, d => d.MapFrom(o => o.Id))
                    .ForMember(c => c.Name, d => d.MapFrom(o => o.Name))
                    .ForMember(c => c.Surname, d => d.MapFrom(o => o.Surname))
                    .ForMember(c => c.Age, d => d.MapFrom(o => o.Age));
            });

            //CreateMap<Quote, QuoteDTO>()
            //    .ForMember(c => c.Id, d => d.MapFrom(o => o.Id))
            //    .ForMember(c => c.AuthorId, d => d.MapFrom(o => o.AuthorId))
            //    .ForMember(c => c.Date, d => d.MapFrom(o => o.Date))
            //    .ForMember(c => c.Text, d => d.MapFrom(o => o.Text));
            //CreateMap<QuoteDTO, Quote>();

        }
    }
}
