namespace PokeAPIManagement.Data.DataEntities
{

    public class PokeTypesEntities
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Result[] results { get; set; }

        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}
