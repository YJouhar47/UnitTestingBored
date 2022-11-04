using System;

namespace PRO2ST2223PE;

class Program
{
    static void Main(string[] args)
    {
        BoredService boredService = new BoredService();
        boredService.BoredVullen();
        boredService.BoredRandom();
    }
}
