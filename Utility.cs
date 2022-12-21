using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace PrjWen
{
    public  class Utility
    {
        private readonly ILogger _logger;

        public Utility()
        {
            
        }
        public  void Logger(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
