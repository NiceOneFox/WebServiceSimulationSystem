using Api.Entities;
using AutoMapper;
using Bll.Domain.Models;
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
                opt => opt.MapFrom(src => src.Item1.AverageProbabilityOfMaintenance))
            .ForMember(dst => dst.ProbabilityOfFailure,
                opt => opt.MapFrom(src => src.Item1.ProbabilityOfFailure))
            .ForMember(dst => dst.BandwidthOfSystem,
                opt => opt.MapFrom(src => src.Item1.BandwidthOfSystem))
            .ForMember(dst => dst.AmountOfGeneratedRequests,

                opt => opt.MapFrom(src => src.Item2.AmountOfGeneratedRequests))
            .ForMember(dst => dst.AmountOfServedRequest,
                opt => opt.MapFrom(src => src.Item2.AmountOfServedRequest))
            .ForMember(dst => dst.ModelingTime,
                opt => opt.MapFrom(src => src.Item2.ModelingTime));
    }
}