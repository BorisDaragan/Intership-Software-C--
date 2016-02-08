using Newtonsoft.Json;
using ResponseRandomOrgApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomOrgApi
{
    public class RandomAPINumberGenerator
    {
        public Queue<int> randQueue;
        public bool randOrgIsAvailable;
        private Random rand;
        private int max;
        public RandomAPINumberGenerator()
        {
            randOrgIsAvailable = true;
            rand = new Random();
            randQueue = new Queue<int>();
        }
        public int GetNumber(int inpMax)
        {
            if (randQueue.Count > 0 && max == inpMax)
            {
                return randQueue.Dequeue();
            }
            else
            {
                max = inpMax;
                if(!randOrgIsAvailable)
                {
                    return rand.Next(max + 1);
                }
                else
                {
                    try
                    {
                        GetQueue(max);
                    }
                    catch(Exception ex)
                    {
                        randOrgIsAvailable = false;
                        return rand.Next(max + 1);
                    }
                    return rand.Next(max + 1);
                }
            }
        }

        private async void GetQueue( int max)
        {
            RandomOrgAPIRequest RequestToRandom = new RandomOrgAPIRequest(max);
            string jsonContent = JsonConvert.SerializeObject(RequestToRandom);
            string url = " https://api.random.org/json-rpc/1/invoke";
            PostRequest request = new PostRequest(url, jsonContent);

            string result = await GetResponse(request);

            if (result != "404")
            {
                RandomOrgAPIResponse responseRandomOrg = JsonConvert.DeserializeObject<RandomOrgAPIResponse>(result);
                randQueue = new Queue<int>(responseRandomOrg.GetNumbers());
            }
            else
            {
                randOrgIsAvailable = false;
            }
        }
        private Task<string> GetResponse (PostRequest request)
        {
            return Task.Run(() =>
                {
                    string result = request.SimplePOST();
                    return result;
                });
        }
    }
}
