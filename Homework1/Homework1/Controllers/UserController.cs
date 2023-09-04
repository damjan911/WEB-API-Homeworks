using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]

		public ActionResult<string> GetAll()
		{
			try
			{
				var userNames = StaticDb.UserNames;
				return Ok(userNames);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while processing the request.");
			}
		}

		[HttpGet("userId/{id}")]

		public ActionResult<string> Get(int id)
		{
			try
			{
				if(id == null)
				{
					return BadRequest("The Id can not be null. Please enter again ! ");
				}

				if(id >= StaticDb.UserNames.Count || id < 0)
				{
					return StatusCode(StatusCodes.Status404NotFound, $"The UserName with Id:{id} can not be found.");
				}

				var userName = StaticDb.UserNames;
				return Ok(userName);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while processing the request.");
			}
		}
	}
}
