namespace RandomOrgApi
{

    class RandomOrgAPIRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public RandomOrgRequestParams @params { get; set; }
        public int id { get; set; }
        public RandomOrgAPIRequest(int max)
        {
            jsonrpc = "2.0";
            method = "generateIntegers";
            @params = new RandomOrgRequestParams(max);
            id = 42;
        }
    }

    public class RandomOrgRequestParams
    {
        public string apiKey { get; set; }
        public int n { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public bool replacement { get; set; }
        public RandomOrgRequestParams(int inpMax = 100)
        {
            apiKey = "5dbb7932-f1eb-4987-a1c0-d40889b115db";
            n = 3; //For tests. In real app   n => 100
            min = 0;
            max = inpMax;
            replacement = true;
        }
    }
}
