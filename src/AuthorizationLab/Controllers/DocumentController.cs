using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationLab.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationLab.Controllers {
    public class DocumentController : Controller {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository) {
            _documentRepository = documentRepository;
        }

        // GET: /<controller>/
        public virtual async Task<IActionResult> Index() {
            return View(_documentRepository.GetDocuments());
        }

        public virtual async Task<IActionResult> Edit(int id) {
            var document = _documentRepository.GetDocument(id);

            if (document == null) {
                return NotFound();
            }
            else {
                return View(document);
            }
        }
    }
}