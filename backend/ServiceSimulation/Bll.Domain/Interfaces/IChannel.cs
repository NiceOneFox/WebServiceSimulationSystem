using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IChannel
{
    void AddRequest(Request request);
}