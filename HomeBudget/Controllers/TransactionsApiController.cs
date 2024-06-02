using AutoMapper;
using HomeBudget.Models;
using HomeBudget.Models.Entities.Api;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsApiController : ControllerBase
    {
        private ITransactionService _transactionService;
        private IMapper _mapper;
        public TransactionsApiController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var transactions = _transactionService.GetAllTransactions();
            var res = _mapper.Map<IEnumerable<GetTransactionsResponse>>(transactions);
            return Ok(res);
        }
        
        [HttpGet]
        [Route("TransactionByType")]
        public IActionResult Get(TransactionType transactionType)
        {
            var transactions = _transactionService.GetTransactionsByType(transactionType);
            var res = _mapper.Map<IEnumerable<GetTransactionsResponse>>(transactions);
            return Ok(res);
        }
        
        [HttpGet]
        [Route("TransactionByCategory")]
        public IActionResult GetTransactionByCategory(int categoryId)
        {
            var transactions = _transactionService.GetTransactionsByCategory(categoryId);
            var res = _mapper.Map<IEnumerable<GetTransactionsResponse>>(transactions);
            return Ok(res);
        }
        
        [HttpGet]
        [Route("TransactionByUser")]
        public IActionResult GetTransactionByUser(int userId)
        {
            var transactions = _transactionService.GetTransactionsByUser(userId);
            var res = _mapper.Map<IEnumerable<GetTransactionsResponse>>(transactions);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound(new { message = "Transaction not found" });
            }
            var transactionResponse = _mapper.Map<GetTransactionsResponse>(transaction);
            return Ok(transactionResponse);
        }

        [HttpPost]
        public IActionResult Post(PostTransactionsRequest transaction)
        {
            var transactionResponse =
                _mapper.Map<GetTransactionsResponse>(
                    _transactionService.AddTransaction(_mapper.Map<TransactionBLL>(transaction)));
            return Ok(transactionResponse);
        }

        [HttpPut]
        public IActionResult Put(PutTransactionsRequest transaction)
        {
            var transactionResponse =
                _mapper.Map<GetTransactionsResponse>(
                    _transactionService.UpdateTransaction(_mapper.Map<TransactionBLL>(transaction)));
            return Ok(transactionResponse);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound(new { message = "Transaction not found" });
            }

            var res = _mapper.Map<GetTransactionsResponse>(_transactionService.DeleteTransaction(id));
            return Ok(res);
        }
    }
}
