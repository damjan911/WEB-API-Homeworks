using Homework2.Model;

namespace Homework2
{
	public static class StaticDb
	{
		public static List<Book> Books = new List<Book>()
		{
			new Book()
			{
				Author = "Harper Lee",
				Title = "To Kill a Mockingbird"
			},
			new Book()
			{
				Author = "Francis Ford Coppola",
				Title = "The Godfather"
			},
			new Book()
			{
				Author = "Orson Welles",
				Title = "Citizen Kane"
			},
			new Book()
			{
				Author = "Frank Darabont",
				Title = "The Shawshank Redemption"
			},
			new Book()
			{
				Author = "Quentin Tarantino",
				Title = "Pulp Fiction"
			},
			new Book()
			{
				Author = "Christopher Nolan",
				Title = "The Dark Knight"
			},
			new Book()
			{
				Author = "Steven Spielberg",
				Title = "Schindler's List"
			},
			new Book()
			{
				Author = "George Lucas",
				Title = "Star Wars: Episode IV - A New Hope"
			},
			new Book()
			{
				Author = "James Cameron",
				Title = "Avatar"
			}
		};
	}
}
