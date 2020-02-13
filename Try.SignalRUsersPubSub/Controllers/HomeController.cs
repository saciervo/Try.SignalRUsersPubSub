namespace Try.SignalRUsersPubSub.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using Hub;
    using Microsoft.AspNetCore.SignalR;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHubContext<NotificationsHub> hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationsHub> hubContext)
        {
            this.logger = logger;
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartJob()
        {
            Task.Factory.StartNew(DoLongRunningWork);
            return Ok("started");
        }

        private void DoLongRunningWork()
        {
            // Simulate hard work
            Thread.Sleep(TimeSpan.FromSeconds(3));

            // Notify clients that the job has been completed.
            hubContext.Clients.User("johnny").SendAsync("jobCompleted", Guid.NewGuid().ToString("N"));
        }
    }
}
