using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface ISourceManager
{
    Request GetNewRequest(Source source);
}