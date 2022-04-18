using Bll.Domain.Services;

namespace Bll.Domain.Entities;

public class StandardBufferManager : IBufferManager
{
    public readonly LinkedList<Request> requests = new();

    public const int Capacity = 5;

    public void Add(Request request)
    {
        if (requests.Count >= Capacity)
        {
            var removedRequest = requests.Last();
            requests.RemoveLast();
            // TODO ADD ALL DELETED REQUESTS TO SOME LOGS OR SOURCE. variable removedRequest
        }

        requests.AddFirst(request);
    }

    public Request? Get()
    {
        if (requests.Count == 0)
        {
            return null; // TODO THROW EXCEPTION?
        }

        var requestFromBuffer = requests.Last();
        requests.RemoveLast();

        return requestFromBuffer;
    }

}