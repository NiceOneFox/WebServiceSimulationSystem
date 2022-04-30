using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities
{
    public class LIFOBufferManager : IBufferManager
    {
        private readonly IResults _results;

        private readonly ITimeProvider _time;

        private readonly LinkedList<Request> _requests = new();

        public readonly int Capacity = 4;

        public LIFOBufferManager(IResults resultChannel, ITimeProvider time, int capacity)
        {
            _results = resultChannel;
            _time = time;
            Capacity = capacity;
        }

        public void Add(Request request)
        {
            if (_requests.Count >= Capacity)
            {
                var removedRequest = _requests.Last();
                _requests.RemoveLast();

                removedRequest.EndTime = _time.Now;
                _results.Cancelled.Add(removedRequest);
            }

            _requests.AddFirst(request);
        }

        public Request Get()
        {
            if (IsFree()) throw new ArgumentNullException("Buffer was empty"); // TODO template string for Ex

            var requestFromBuffer = _requests.First();
            _requests.RemoveFirst();

            return requestFromBuffer;
        }

        public bool IsFree() => _requests.Count == 0;
    }
}
