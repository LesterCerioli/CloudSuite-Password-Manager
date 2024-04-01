using AutoMapper;
using NetDevPack.Messaging;
using PasswordGenerator.Application.ViewModels;
using PasswordGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Password, PasswordViewModel>();
        }
    }
}
