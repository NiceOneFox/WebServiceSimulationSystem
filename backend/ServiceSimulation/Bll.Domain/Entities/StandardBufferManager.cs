using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class StandardBufferManager : IBufferManager
{
    private readonly LinkedList<Request> _requests = new();

    public const int Capacity = 5;

    public void Add(Request request)
    {
        if (_requests.Count >= Capacity)
        {
            var removedRequest = _requests.Last();
            _requests.RemoveLast();
            // TODO ADD ALL DELETED REQUESTS TO SOME LOGS OR SOURCE. variable removedRequest
        }

        _requests.AddFirst(request);
    }

    public Request? Get()
    {
        if (_requests.Count == 0)
        {
            return null; // TODO THROW EXCEPTION?
        }

        var requestFromBuffer = _requests.Last();
        _requests.RemoveLast();

        return requestFromBuffer;
    }

}