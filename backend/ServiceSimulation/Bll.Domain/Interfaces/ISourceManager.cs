using Bll.Domain.Models;

namespace Bll.Domain.Interfaces;

public interface ISourceManager
{
    Request GetNewRequest(Source source);
}