using BlazorApp6.Data;
using BlazorApp6.Models;

Console.WriteLine("6.4.1 データ参照方法");

using (PubsDbContext context = new PubsDbContext())
{
    Console.WriteLine("\n" + "n 件データ取得");

    var query1 = from a in context.Authors where a.State == "CA" select a;
    List<Author> authors = query1.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine("{0}: {1}, {2}", author.AuthorId, author.AuthorLastName, author.AuthorFirstName);
    }

    Console.WriteLine("\n" + "1 件データ取得");

    var query2 = from a in context.Authors where a.AuthorId == "172-32-1176" select a;
    Author? authors2 = query2.FirstOrDefault();

    if (authors2 != null)
    {
        Console.WriteLine("{0}: {1}, {2}", authors2.AuthorId, authors2.AuthorLastName, authors2.AuthorFirstName);
    }
}
