using Bll.Domain.Services;

namespace Bll.Domain.Entities;

public class Source : ISource
{
    public int SourceId { get; set; }
    public int Priority { get; set; }
    public int SerialNumber { get; set; }
    public Request GetNewRequest()
    {
        var generatedRequest = new Request(SourceId, SerialNumber, DateTime.Now, DateTime.Now.AddMilliseconds(5.0));
        SerialNumber++;
        return generatedRequest;
    }
}

class Source
{
    public Request sourceRequests { get; set; }
    public int numberSource { get; set; }
    public int serialNumber { get; set; } = 0;

    public int priority { get; set; } = 0;

    public int declined { get; set; } = 0;

    public float Tpreb { get; set; } = 0;

    public float TObcl { get; set; } = 0;

    public float Tbp { get; set; } = 0;

    public int TbpAmount { get; set; } = 0; // кол-во заявок в буфере этого источника

    public List<float> allRequetsOfSource { get; set; }

    public List<float> allTbp { get; set; }

    public Source(int numberSource, int serialNumber, int priority)
    {
        this.numberSource = numberSource;
        this.serialNumber = serialNumber;
        this.priority = priority;
        this.declined = 0;
        this.TObcl = 0;
        this.Tbp = 0;
        allRequetsOfSource = new List<float>();
        allTbp = new List<float>();
        // random first request
        sourceRequests = new Request(Program.time + ((float)Program.random.NextDouble()) / 100, numberSource, serialNumber);
        serialNumber++;
        allRequetsOfSource.Add(sourceRequests.dateTime);
    }

    public Source() { }

    public float GetTimeRequest()
    {
        if (sourceRequests == null) return -1;
        return sourceRequests.dateTime;
    }

    public Request GetNewRequest() // отдаём текущую сгенирированную и генерируем новую
    {
        Request temp = this.sourceRequests;
        float prevTime = temp.dateTime;

        serialNumber++;
        sourceRequests = null;
        // генерировать следующую заявку источника           
        sourceRequests = new Request(prevTime + Program.timeOfSourceGenerateNewRequest, numberSource, serialNumber);

        Program.numberOfRequestsWereGenerated++;

        if (Program.numberOfRequestsWereGenerated >= Program.totalRequestGenerate)
        {
            sourceRequests = null;
            // больше не генерируем
        }

        Program.allRequestInSystem.Add(temp);
        allRequetsOfSource.Add(temp.dateTime);
        // возращаем текущую
        return temp;
    }