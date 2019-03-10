using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace SweetShop.PayPal
{
    public class PayPalService
    {
        public static PayPalConfig GetPayPalConfig()
        {
            var bulider = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = bulider.Build();
            return new PayPalConfig()
            {
                AuthToken = configuration["PayPal:AuthToken"],
                PostUrl = configuration["PayPal:PostUrl"],
                Business = configuration["PayPal:Business"],
                ReturnUrl = configuration["PayPal:ReturnUrl"]
            };
        }
    }
}
