using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Task.Data.Entities;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    public class ImportController : Controller
    {
        private readonly ILogger<ImportController> _logger;
        private readonly IImportService _importService;

        public ImportController(ILogger<ImportController> logger, IImportService importService)
        {
            _logger = logger;
            _importService = importService;
        }

        public IActionResult Index()
        {
            var list = _importService.GetRequestList();
            return View(list);
        }

        public IActionResult CreateNewRequest()
        {
            var model = new ImportRequestResponseViewModel()
            {
                ItemsList=_importService.getItemsList(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateNewRequest(ImportRequestResponseViewModel input)
        {
            var result = _importService.CreateRequest(input);
            return Json(result);
        }
        public IActionResult ViewRequest(int Id)
        {
            var model = _importService.GetRequestForView(Id);
            return View( model);
        }

    }
}
