using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Task.BL.Abstract;

namespace Task.BL.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<JObject> GetCustomersByNameAsync(string customerName)
        {
            //TODO add method to DAL
            //var customers =  await _customerRepo.GetAllCustomersAsync();
            //var result = customers.Where(x => x.Name == customerName);
            // return result;
            // change the type of result, it could just simple Dto, i.e. CustomerDto

            //заглушка
            return default;
        }
    }
}
