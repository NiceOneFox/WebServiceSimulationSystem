using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface ISource
{
    Request GetNewRequest();
}