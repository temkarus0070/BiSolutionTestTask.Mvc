namespace BiSolutionTestTask.Mvc.Services
{
    public class AppService
    {
        private IHttpClientFactory _httpClientFactory;
        public AppService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> IsPalindrome(string str)
        {
            var httpClient = _httpClientFactory.CreateClient("app");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "check-palindrome-string");
            httpRequest.Content = JsonContent.Create(str);
            bool result = await httpClient.SendAsync(httpRequest).Result.Content.ReadFromJsonAsync<bool>();
            return result;
        }
        public async Task<IEnumerable<int>> SortList(IEnumerable<int> ints)
        {
            var httpClient = _httpClientFactory.CreateClient("app");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "sort-list");
            httpRequest.Content = JsonContent.Create(ints);
            IEnumerable<int> result = await httpClient.SendAsync(httpRequest).Result.Content.ReadFromJsonAsync<IEnumerable<int>>();
            return result;
        }
        public async Task<long> AddSecondOddArrayNumbers(int[] ints)
        {
            var httpClient = _httpClientFactory.CreateClient("app");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "add-second-odd-array-numbers");
            httpRequest.Content = JsonContent.Create(ints);
            long result = await httpClient.SendAsync(httpRequest).Result.Content.ReadFromJsonAsync<long>();
            return result;
        }
    }
}
