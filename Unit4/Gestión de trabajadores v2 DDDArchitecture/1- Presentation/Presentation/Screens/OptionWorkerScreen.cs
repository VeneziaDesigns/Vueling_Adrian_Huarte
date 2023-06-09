using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.IServices;

namespace Presentation.Screens
{
    public class OptionWorkerScreen
    {
        private readonly IWorkersServices _workersServices;

        public OptionWorkerScreen(IWorkersServices workersServices)
        {
            _workersServices = workersServices;
        }

        public void Start()
        {
            //RegisterNewITWorker();
            //TODO
        }  
    }
}
