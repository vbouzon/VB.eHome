using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VB.eHome
{
    [Route("api/[controller]")]
    public class GatesController
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            GpioController controller = new GpioController(PinNumberingScheme.Board);
            var pin = 11;
            var lightTime = 800;

            controller.OpenPin(pin, PinMode.Output);
            try
            {
                while (true)
                {
                    controller.Write(pin, PinValue.High);
                    Thread.Sleep(lightTime);
                    controller.Write(pin, PinValue.Low);
                    Thread.Sleep(lightTime);
                }
            }
            finally
            {
                controller.ClosePin(pin);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
