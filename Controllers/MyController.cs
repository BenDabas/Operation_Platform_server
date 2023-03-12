using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Operation_Platform.Data;

namespace Operation_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public MyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MyData>> Get()
        {
            var a = _dataContext.Database.EnsureCreated();

            // Retrieve data from a database or other source
            var data = new List<MyData>
            {
                new MyData { Id = 1, Name = "Data 1" },
                new MyData { Id = 2, Name = "Data 2" },
                new MyData { Id = 3, Name = "Data 3" }
            };

            return Ok(data);
        }
    }

    public class MyData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}