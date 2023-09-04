using Homework2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		// Add GET method that returns all books


		[HttpGet]

		public ActionResult<List<Book>> GetAllBooks()
		{
			return Ok(StaticDb.Books);
		}

		// Add GET method that returns one book by sending index in the query string



		[HttpGet("{id}")]

		public ActionResult<Book> GetByBook(int? id)
		{
			try
			{
				if (id == null)
				{
					return StatusCode(StatusCodes.Status400BadRequest, "An error occured.Id can not be null.");
				}

				if (id < 0)
				{
					return StatusCode(StatusCodes.Status400BadRequest, "An error occured.Id can not be a negative number.");
				}

				if (id >= StaticDb.Books.Count)
				{
					return StatusCode(StatusCodes.Status404NotFound, $"There is not book with Index: {id}");
				}

				return Ok(StaticDb.Books[id.Value]);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
			}
			

		}

		// Add GET method that returns one book by filtering by author and title (use query string parameters)

		[HttpGet("authorTitle")]

		public ActionResult<Book> FilterBookByMultipleQueryParams (string? author,  string? title)
		{
			try
			{
				if(string.IsNullOrEmpty(author) && title == null)
				{
					return BadRequest("Insert at least one query paramater");
				}
				
				Book filteredBook = StaticDb.Books.FirstOrDefault(book => book.Author.ToLower() == author.ToLower() && book.Title.ToLower() == title.ToLower());

				if (filteredBook == null)
				{
					return BadRequest("There is no Book with that Author.");
				}

				return Ok(filteredBook);
			}
			catch (Exception ex)
			{
               return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");

			}
		}

		// Add POST method that adds new book to the list of books (use the FromBody attribute).

		[HttpPost]

		public ActionResult CreateBook([FromBody] Book book)
		{
			try
			{
				if (string.IsNullOrEmpty(book.Author))
				{
					return BadRequest("Please enter Author of the Book");
				}

				if (string.IsNullOrEmpty(book.Title))
				{
					return BadRequest("Please enter Title of the Book");
				}

				StaticDb.Books.Add(book);
				return StatusCode(StatusCodes.Status201Created, "The new Book is already successfully created");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
			}
		}


	}
}
