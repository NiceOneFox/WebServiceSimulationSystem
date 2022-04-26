using Api.Entities;
using AutoMapper;
using Bll.Domain.Entities;
using Bll.Domain.Interfaces;

namespace Api.Configuration;

public class ApiMapperConfigurator
{
    private readonly IMapperConfigurationExpression _expression;
    public IMapperConfigurationExpression AddConfiguration() => _expression;

    public ApiMapperConfigurator(IMapperConfigurationExpression expression)
    {
        MappingApiResults(expression);

        _expression = expression;
    }

    private void MappingApiResults(IMapperConfigurationExpression expression)
    {
        expression.CreateMap<(FinalResults, IResults), ApiResults>()
            .ForMember(dst => dst.AverageProbabilityOfMaintenance, 
                opt => opt.MapFrom(src => src.Item1.AverageProbabilityOfMaintenance));
        //TODO CONTINUE MAP MEMBERS
    }
}