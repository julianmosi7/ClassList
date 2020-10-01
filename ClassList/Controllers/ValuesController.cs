using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassListDb;

namespace ClassList.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
	private readonly ClassListContext db;
	public ValuesController(ClassListContext db)
	{
	  this.db = db;
	}
	  
    [HttpGet("GetStudents")]
    public object GetStudents()
    {
      try
      {
        int nr = db.Students.Count();
        return new { IsOk = true, Nr = nr };
      }
      catch (Exception exc)
      {
        return new { IsOk = false, Nr = -1, Error = exc.Message };
      }
    }

  }
}
