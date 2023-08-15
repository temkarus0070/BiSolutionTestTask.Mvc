using BiSolutionTestTask.WebAPI.models;
using BiSolutionTestTask.WebAPI.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiSolutionTestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private WebApiService appService;

        public AppController(WebApiService appService)
        {
            this.appService = appService;
        }

        [HttpPost("sort-list")]
        public MyDoubleLinkedList<int> SortList([FromBody] List<int> intList)
        {
            return this.appService.Sort(intList);
        }

        [HttpPost("add-second-odd-array-numbers")]
        public long AddSecondOddArrayNumbers([FromBody] int[] intArray)
        {
            return this.appService.AddEverySecondOddNumber(intArray);
        }

        [HttpPost("check-palindrome-string")]
        public bool CheckPalindromeString([FromBody] string str)
        {
            return this.appService.IsPalindrome(str);
        }
    }
}
