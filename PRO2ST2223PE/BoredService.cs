using System;

namespace PRO2ST2223PE;

public class BoredService : IBoredService
{
    public BoredService(){}
    private readonly IBoredApiService _boredServiceApi;
    public BoredService(IBoredApiService boredServiceApi)
    {
        this._boredServiceApi = boredServiceApi;
    }
    public void BoredVullen()
    {

        BoredInMemoryDb.boredResponses.Clear();
        for (int i = 0; i < 10; i++)
        {
            BoredInMemoryDb.boredResponses.Add(_boredServiceApi.GetBoredResponse());
        }
    }
    public string BoredRandom()
    {
        Random random = new Random();
        BoredResponse boredResponse = BoredInMemoryDb.boredResponses[random.Next(10)];
        if (boredResponse.Participants < 2)
        {
            return $"I don't have enough friends to => {boredResponse.Activity}";
        }
        else
        {
            return $"Let's do some => {boredResponse.Activity}";
        }
    }
}
