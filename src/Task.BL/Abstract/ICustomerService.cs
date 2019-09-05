using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task.BL.Abstract
{
    public interface ICustomerService
    {
        Task<JObject> GetCustomersByNameAsync(string customerName);
    }
}
