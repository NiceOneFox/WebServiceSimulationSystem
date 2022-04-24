using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class StandardBufferManager : IBufferManager
{
   private readonly IResults _resultChannel;

   private readonly ITimeProvider _time;

    private readonly LinkedList<Request> _requests = new();

    public const int Capacity = 5;

    public StandardBufferManager(IResults resultChannel, ITimeProvider time)
    {
        _resultChannel = resultChannel;
        _time = time;
    }

    public void Add(Request request)
    {
        if (_requests.Count >= Capacity)
        {
            var removedRequest = _requests.Last();
            _requests.RemoveLast();

            removedRequest.EndTime = _time.Now;
            _resultChannel.Cancelled.Add(removedRequest);
        }

        _requests.AddFirst(request);
    }

    public Request Get()
    {
        if (IsFree()) throw new ArgumentNullException("Buffer was empty"); // TODO template string for Ex

        var requestFromBuffer = _requests.Last();
        _requests.RemoveLast();

        return requestFromBuffer;
    }

    public bool IsFree() => _requests.Count == 0;
}