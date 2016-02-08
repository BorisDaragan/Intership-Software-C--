using System.Collections.Generic;

namespace ResponseRandomOrgApi
{

 
    class RandomOrgAPIResponse
    {
        public string jsonrpc { get; set; }
        public Result result { get; set; }
        public int id { get; set; }
        public List<int> GetNumbers()
        {
            return result.random.data;
        }

        //To do:
        //1. public string Serialize()
        //2. make fields private
    }
    public class ResponseRandom
    {
        public List<int> data { get; set; }
        public string completionTime { get; set; }
    }

    public class Result
    {
        public ResponseRandom random { get; set; }
        public int bitsUsed { get; set; }
        public int bitsLeft { get; set; }
        public int requestsLeft { get; set; }
        public int advisoryDelay { get; set; }
    }
}
