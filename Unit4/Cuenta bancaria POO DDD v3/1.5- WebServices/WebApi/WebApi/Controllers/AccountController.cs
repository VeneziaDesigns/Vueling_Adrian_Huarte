using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Domain;

namespace WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        //public List<Account> Get() 
        //{
        //    List<Account> result = _service.GetList();

        //    return result;
        //}
        
    }
}
