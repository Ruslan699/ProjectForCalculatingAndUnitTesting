using AteshgahApp.Core.Models;
using AteshgahApp.Core.Services;
using AteshgahApp.UI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AteshgahApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IClientService _clientService;
        private readonly InvoiceService _invoiceService;
        private readonly IMapper _mapper;
        public HomeController(ILoanService loanService, 
                               ClientService clientService,
                                InvoiceService invoiceService,
                                 IMapper mapper)
        {
            _loanService = loanService;
            _clientService = clientService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var data = _mapper.Map<List<LoanViewModel>>(await _loanService.GetAllLoansAsync());
            return View(data);
        }

        public async Task<ActionResult> LoanDetails(int Id)
        {
            var data = _mapper.Map<LoanDetailsViewModel>(await _loanService.GetLoansDetailAsync(Id));
            return View(data);
        }

        public async Task<ActionResult> Create()
        {
            var clients = _mapper.Map<IEnumerable<ClientViewModel>>(await _clientService.GetAllClientsAsync());
            return View(clients);
        }

        [HttpPost]
        public async Task<ActionResult> Estimate(EstimateViewModel model)
        {
            var list = new List<InvoiceViewModel>();

            if (ModelState.IsValid)
            {
                var data = await _invoiceService.EstimateInvoicesAsync(_mapper.Map<Loan>(model));

                TempData["estimateError"] = null;

                list.AddRange(_mapper.Map<List<InvoiceViewModel>>(data));
            }
            else
                ModelState.AddModelError("*", TempData["estimateError"].ToString());


            return PartialView(list);
        }

        public async Task<ActionResult> AddInvoice(EstimateViewModel model)
        {
            try
            {
                var list = new List<InvoiceViewModel>();

                if (ModelState.IsValid)
                {
                    var loan = _mapper.Map<Loan>(model);
                    var data = await _invoiceService.EstimateInvoicesAsync(loan);
                    await _invoiceService.AddInvoiceAsync(loan, data);

                    list.AddRange(_mapper.Map<List<InvoiceViewModel>>(data));
                }
                else
                    return Json(new { status = 500 }, JsonRequestBehavior.AllowGet);

                return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {
                return Json(new { status = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}