using BiSolutionTestTask.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace BiSolutionTestTask.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppService _appService;

        public HomeController(ILogger<HomeController> logger, AppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEverySecondOddNumber() { return View(); }


        [HttpPost]
        public async Task<IActionResult> AddEverySecondOddNumber([FromForm] string array)
        {
            int[] intArray = array.Trim().Split(" ").Select(x => int.Parse(x)).ToArray<int>();
            long res = await _appService.AddSecondOddArrayNumbers(intArray);
            ViewData["result"] = res;
            return View();
        }

        [HttpGet]
        public IActionResult checkPalindrome() { return View(); }


        [HttpPost]
        public async Task<IActionResult> checkPalindrome([FromForm] string str)
        {
            bool res = await _appService.IsPalindrome(str);
            ViewData["result"] = res;
            return View();
        }

        [HttpGet]
        public IActionResult sortList() { return View(); }


        [HttpPost]
        public async Task<IActionResult> sortList([FromForm] string listInStr)
        {
            List<int> intArray = listInStr.Trim().Split(" ").Select(x => int.Parse(x)).ToList();
            IEnumerable<int> res = await _appService.SortList(intArray);
            ViewData["result"] = res;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}