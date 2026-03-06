using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp6.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Model
{
    public static class Seed
    {
        public static async Task InitializeAsync(IServiceProvider provider)
        {
            using var db = provider.GetRequiredService<PubsDbContext>();
            if (await db.Authors.AnyAsync() || await db.Publishers.AnyAsync() || await db.Stores.AnyAsync() || await db.Titles.AnyAsync())
            {
                return; // DB has been seeded
            }

            await db.Authors.AddRangeAsync(
                new Author { AuthorId = "409-56-7008", AuthorFirstName = "Bennet", AuthorLastName = "Abraham", Phone = "415 658-9932", Address = "6223 Bateman St.", City = "Berkeley", State = "CA", Zip = "94705", Contract = true },
                new Author { AuthorId = "213-46-8915", AuthorFirstName = "Green", AuthorLastName = "Marjorie", Phone = "415 986-7020", Address = "309 63rd St. #411", City = "Oakland", State = "CA", Zip = "94618", Contract = true },
                new Author { AuthorId = "238-95-7766", AuthorFirstName = "Carson", AuthorLastName = "Cheryl", Phone = "415 548-7723", Address = "589 Darwin Ln.", City = "Berkeley", State = "CA", Zip = "94705", Contract = true },
                new Author { AuthorId = "998-72-3567", AuthorFirstName = "Ringer", AuthorLastName = "Albert", Phone = "801 826-0752", Address = "67 Seventh Av.", City = "Salt Lake City", State = "UT", Zip = "84152", Contract = true },
                new Author { AuthorId = "899-46-2035", AuthorFirstName = "Ringer", AuthorLastName = "Anne", Phone = "801 826-0752", Address = "67 Seventh Av.", City = "Salt Lake City", State = "UT", Zip = "84152", Contract = true },
                new Author { AuthorId = "722-51-5454", AuthorFirstName = "DeFrance", AuthorLastName = "Michel", Phone = "219 547-9982", Address = "3 Balding Pl.", City = "Gary", State = "IN", Zip = "46403", Contract = true },
                new Author { AuthorId = "807-91-6654", AuthorFirstName = "Panteley", AuthorLastName = "Sylvia", Phone = "301 946-8853", Address = "1956 Arlington Pl.", City = "Rockville", State = "MD", Zip = "20853", Contract = true },
                new Author { AuthorId = "893-72-1158", AuthorFirstName = "McBadden", AuthorLastName = "Heather", Phone = "707 448-4982", Address = "301 Putnam", City = "Vacaville", State = "CA", Zip = "95688", Contract = false },
                new Author { AuthorId = "724-08-9931", AuthorFirstName = "Stringer", AuthorLastName = "Dirk", Phone = "415 843-2991", Address = "5420 Telegraph Av.", City = "Oakland", State = "CA", Zip = "94609", Contract = false },
                new Author { AuthorId = "274-80-9391", AuthorFirstName = "Straight", AuthorLastName = "Dean", Phone = "415 834-2919", Address = "5420 College Av.", City = "Oakland", State = "CA", Zip = "94609", Contract = true },
                new Author { AuthorId = "756-30-7391", AuthorFirstName = "Karsen", AuthorLastName = "Livia", Phone = "415 534-9219", Address = "5720 McAuley St.", City = "Oakland", State = "CA", Zip = "94609", Contract = true },
                new Author { AuthorId = "724-80-9391", AuthorFirstName = "MacFeather", AuthorLastName = "Stearns", Phone = "415 354-7128", Address = "44 Upland Hts.", City = "Oakland", State = "CA", Zip = "94612", Contract = true },
                new Author { AuthorId = "427-17-2319", AuthorFirstName = "Dull", AuthorLastName = "Ann", Phone = "415 836-7128", Address = "3410 Blonde St.", City = "Palo Alto", State = "CA", Zip = "94301", Contract = true },
                new Author { AuthorId = "672-71-3249", AuthorFirstName = "Yokomoto", AuthorLastName = "Akiko", Phone = "415 935-4228", Address = "3 Silver Ct.", City = "Walnut Creek", State = "CA", Zip = "94595", Contract = true },
                new Author { AuthorId = "267-41-2394", AuthorFirstName = "O'Leary", AuthorLastName = "Michael", Phone = "408 286-2428", Address = "22 Cleveland Av. #14", City = "San Jose", State = "CA", Zip = "95128", Contract = true },
                new Author { AuthorId = "472-27-2349", AuthorFirstName = "Gringlesby", AuthorLastName = "Burt", Phone = "707 938-6445", Address = "PO Box 792", City = "Covelo", State = "CA", Zip = "95428", Contract = true },
                new Author { AuthorId = "527-72-3246", AuthorFirstName = "Greene", AuthorLastName = "Morningstar", Phone = "615 297-2723", Address = "22 Graybar House Rd.", City = "Nashville", State = "TN", Zip = "37215", Contract = false },
                new Author { AuthorId = "172-32-1176", AuthorFirstName = "White", AuthorLastName = "Johnson", Phone = "408 496-7223", Address = "10932 Bigge Rd.", City = "Menlo Park", State = "CA", Zip = "94025", Contract = true },
                new Author { AuthorId = "712-45-1867", AuthorFirstName = "del Castillo", AuthorLastName = "Innes", Phone = "615 996-8275", Address = "2286 Cram Pl. #86", City = "Ann Arbor", State = "MI", Zip = "48105", Contract = true },
                new Author { AuthorId = "846-92-7186", AuthorFirstName = "Hunter", AuthorLastName = "Sheryl", Phone = "415 836-7128", Address = "3410 Blonde St.", City = "Palo Alto", State = "CA", Zip = "94301", Contract = true },
                new Author { AuthorId = "486-29-1786", AuthorFirstName = "Locksley", AuthorLastName = "Charlene", Phone = "415 585-4620", Address = "18 Broadway Av.", City = "San Francisco", State = "CA", Zip = "94130", Contract = true },
                new Author { AuthorId = "648-92-1872", AuthorFirstName = "Blotchet-Halls", AuthorLastName = "Reginald", Phone = "503 745-6402", Address = "55 Hillsdale Bl.", City = "Corvallis", State = "OR", Zip = "97330", Contract = true },
                new Author { AuthorId = "341-22-1782", AuthorFirstName = "Smith", AuthorLastName = "Meander", Phone = "913 843-0462", Address = "10 Mississippi Dr.", City = "Lawrence", State = "KS", Zip = "66044", Contract = false }
            );

            await db.Publishers.AddRangeAsync(
                new Publisher { PublisherId = "0736", PublisherName = "New Moon Books", City = "Boston", State = "MA", Country = "USA" },
                new Publisher { PublisherId = "0877", PublisherName = "Binnet & Hardley", City = "Washington", State = "DC", Country = "USA" },
                new Publisher { PublisherId = "1389", PublisherName = "Algodata Infosystems", City = "Berkeley", State = "CA", Country = "USA" },
                new Publisher { PublisherId = "9952", PublisherName = "Scootney Books", City = "New York", State = "NY", Country = "USA" },
                new Publisher { PublisherId = "1622", PublisherName = "Five Lakes Publishing", City = "Chicago", State = "IL", Country = "USA" },
                new Publisher { PublisherId = "1756", PublisherName = "Ramona Publishers", City = "Dallas", State = "TX", Country = "USA" },
                new Publisher { PublisherId = "9901", PublisherName = "GGG&G", City = "Munchen", State = null, Country = "Germany" },
                new Publisher { PublisherId = "9999", PublisherName = "Lucerne Publishing", City = "Paris", State = null, Country = "France" }
            );

            await db.Titles.AddRangeAsync(
                new Title { TitleId = "PC8888", TitleName = "Secrets of Silicon Valley", Type = "popular_comp", PublisherId = "1389", Price = 20.00m, Advance = 8000.00m, Royalty = 10, YearToDateSales = 4095, Notes = "Muckraking reporting on the world's largest computer hardware and software manufacturers.", PublishedDate = new DateTime(1994, 6, 12) },
                new Title { TitleId = "BU1032", TitleName = "The Busy Executive's Database Guide", Type = "business", PublisherId = "1389", Price = 19.99m, Advance = 5000.00m, Royalty = 10, YearToDateSales = 4095, Notes = "An overview of available database systems with emphasis on common business applications. Illustrated.", PublishedDate = new DateTime(1991, 6, 12) },
                new Title { TitleId = "PS7777", TitleName = "Emotional Security: A New Algorithm", Type = "psychology", PublisherId = "0736", Price = 7.99m, Advance = 4000.00m, Royalty = 10, YearToDateSales = 3336, Notes = "Protecting yourself and your loved ones from undue emotional stress in the modern world. Use of computer and nutritional aids emphasized.", PublishedDate = new DateTime(1991, 6, 12) },
                new Title { TitleId = "PS3333", TitleName = "Prolonged Data Deprivation: Four Case Studies", Type = "psychology", PublisherId = "0736", Price = 19.99m, Advance = 2000.00m, Royalty = 10, YearToDateSales = 4072, Notes = "What happens when the data runs dry?  Searching evaluations of information-shortage effects.", PublishedDate = new DateTime(1991, 6, 12) },
                new Title { TitleId = "BU1111", TitleName = "Cooking with Computers: Surreptitious Balance Sheets", Type = "business", PublisherId = "1389", Price = 11.95m, Advance = 5000.00m, Royalty = 10, YearToDateSales = 3876, Notes = "Helpful hints on how to use your electronic resources to the best advantage.", PublishedDate = new DateTime(1991, 6, 9) },
                new Title { TitleId = "MC2222", TitleName = "Silicon Valley Gastronomic Treats", Type = "mod_cook", PublisherId = "0877", Price = 19.99m, Advance = 0.00m, Royalty = 12, YearToDateSales = 2032, Notes = "Favorite recipes for quick, easy, and elegant meals.", PublishedDate = new DateTime(1991, 6, 9) },
                new Title { TitleId = "TC7777", TitleName = "Sushi, Anyone?", Type = "trad_cook", PublisherId = "0877", Price = 14.99m, Advance = 8000.00m, Royalty = 10, YearToDateSales = 4095, Notes = "Detailed instructions on how to make authentic Japanese sushi in your spare time.", PublishedDate = new DateTime(1991, 6, 12) },
                new Title { TitleId = "TC4203", TitleName = "Fifty Years in Buckingham Palace Kitchens", Type = "trad_cook", PublisherId = "0877", Price = 11.95m, Advance = 4000.00m, Royalty = 14, YearToDateSales = 15096, Notes = "More anecdotes from the Queen's favorite cook describing life among English royalty. Recipes, techniques, tender vignettes.", PublishedDate = new DateTime(1991, 6, 12) },
                new Title { TitleId = "PC1035", TitleName = "But Is It User Friendly?", Type = "popular_comp", PublisherId = "1389", Price = 22.95m, Advance = 7000.00m, Royalty = 16, YearToDateSales = 8780, Notes = "A survey of software for the naive user, focusing on the 'friendliness' of each.", PublishedDate = new DateTime(1991, 6, 30) },
                new Title { TitleId = "BU2075", TitleName = "You Can Combat Computer Stress!", Type = "business", PublisherId = "0736", Price = 2.99m, Advance = 10125.00m, Royalty = 24, YearToDateSales = 18722, Notes = "The latest medical and psychological techniques for living with the electronic office. Easy-to-understand explanations.", PublishedDate = new DateTime(1991, 6, 30) },
                new Title { TitleId = "PS2091", TitleName = "Is Anger the Enemy?", Type = "psychology", PublisherId = "0736", Price = 10.95m, Advance = 2275.00m, Royalty = 12, YearToDateSales = 2045, Notes = "Carefully researched study of the effects of strong emotions on the body. Metabolic charts included.", PublishedDate = new DateTime(1991, 6, 15) },
                new Title { TitleId = "PS2106", TitleName = "Life Without Fear", Type = "psychology", PublisherId = "0736", Price = 7.00m, Advance = 6000.00m, Royalty = 10, YearToDateSales = 111, Notes = "New exercise, meditation, and nutritional techniques that can reduce the shock of daily interactions. Popular audience. Sample menus included, exercise video available separately.", PublishedDate = new DateTime(1991, 10, 5) },
                new Title { TitleId = "MC3021", TitleName = "The Gourmet Microwave", Type = "mod_cook", PublisherId = "0877", Price = 2.99m, Advance = 15000.00m, Royalty = 24, YearToDateSales = 22246, Notes = "Traditional French gourmet recipes adapted for modern microwave cooking.", PublishedDate = new DateTime(1991, 6, 18) },
                new Title { TitleId = "TC3218", TitleName = "Onions, Leeks, and Garlic: Cooking Secrets of the Mediterranean", Type = "trad_cook", PublisherId = "0877", Price = 20.95m, Advance = 7000.00m, Royalty = 10, YearToDateSales = 375, Notes = "Profusely illustrated in color, this makes a wonderful gift book for a cuisine-oriented friend.", PublishedDate = new DateTime(1991, 10, 21) },
                new Title { TitleId = "MC3026", TitleName = "The Psychology of Computer Cooking", Type = "mod_cook", PublisherId = "0877", Price = null, Advance = null, Royalty = null, YearToDateSales = null, Notes = null, PublishedDate = new DateTime(1991, 6, 19) },
                new Title { TitleId = "BU7832", TitleName = "Straight Talk About Computers", Type = "business", PublisherId = "1389", Price = 19.99m, Advance = 5000.00m, Royalty = 10, YearToDateSales = 4095, Notes = "Annotated analysis of what computers can do for you: a no-hype guide for the critical user.", PublishedDate = new DateTime(1991, 6, 22) },
                new Title { TitleId = "PS1372", TitleName = "Computer Phobic AND Non-Phobic Individuals: Behavior Variations", Type = "psychology", PublisherId = "0877", Price = 21.59m, Advance = 7000.00m, Royalty = 10, YearToDateSales = 375, Notes = "A must for the specialist, this book examines the difference between those who hate and fear computers and those who don't.", PublishedDate = new DateTime(1991, 10, 21) },
                new Title { TitleId = "PC9999", TitleName = "Net Etiquette", Type = "popular_comp", PublisherId = "1389", Price = null, Advance = null, Royalty = null, YearToDateSales = null, Notes = "A must-read for computer conferencing.", PublishedDate = new DateTime(1991, 6, 23) }
            );

            await db.Set<TitleAuthor>().AddRangeAsync(
                new TitleAuthor { AuthorId = "409-56-7008", TitleId = "BU1032", AuthorOrder = 1, RoyaltyPercentage = 60 },
                new TitleAuthor { AuthorId = "486-29-1786", TitleId = "PS7777", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "486-29-1786", TitleId = "PC9999", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "712-45-1867", TitleId = "MC2222", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "172-32-1176", TitleId = "PS3333", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "213-46-8915", TitleId = "BU1032", AuthorOrder = 2, RoyaltyPercentage = 40 },
                new TitleAuthor { AuthorId = "238-95-7766", TitleId = "PC1035", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "213-46-8915", TitleId = "BU2075", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "998-72-3567", TitleId = "PS2091", AuthorOrder = 1, RoyaltyPercentage = 50 },
                new TitleAuthor { AuthorId = "899-46-2035", TitleId = "PS2091", AuthorOrder = 2, RoyaltyPercentage = 50 },
                new TitleAuthor { AuthorId = "998-72-3567", TitleId = "PS2106", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "722-51-5454", TitleId = "MC3021", AuthorOrder = 1, RoyaltyPercentage = 75 },
                new TitleAuthor { AuthorId = "899-46-2035", TitleId = "MC3021", AuthorOrder = 2, RoyaltyPercentage = 25 },
                new TitleAuthor { AuthorId = "807-91-6654", TitleId = "TC3218", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "274-80-9391", TitleId = "BU7832", AuthorOrder = 1, RoyaltyPercentage = 100 },
                new TitleAuthor { AuthorId = "427-17-2319", TitleId = "PC8888", AuthorOrder = 1, RoyaltyPercentage = 50 },
                new TitleAuthor { AuthorId = "846-92-7186", TitleId = "PC8888", AuthorOrder = 2, RoyaltyPercentage = 50 },
                new TitleAuthor { AuthorId = "756-30-7391", TitleId = "PS1372", AuthorOrder = 1, RoyaltyPercentage = 75 },
                new TitleAuthor { AuthorId = "724-80-9391", TitleId = "PS1372", AuthorOrder = 2, RoyaltyPercentage = 25 },
                new TitleAuthor { AuthorId = "724-80-9391", TitleId = "BU1111", AuthorOrder = 1, RoyaltyPercentage = 60 },
                new TitleAuthor { AuthorId = "267-41-2394", TitleId = "BU1111", AuthorOrder = 2, RoyaltyPercentage = 40 },
                new TitleAuthor { AuthorId = "672-71-3249", TitleId = "TC7777", AuthorOrder = 1, RoyaltyPercentage = 40 },
                new TitleAuthor { AuthorId = "267-41-2394", TitleId = "TC7777", AuthorOrder = 2, RoyaltyPercentage = 30 },
                new TitleAuthor { AuthorId = "472-27-2349", TitleId = "TC7777", AuthorOrder = 3, RoyaltyPercentage = 30 },
                new TitleAuthor { AuthorId = "648-92-1872", TitleId = "TC4203", AuthorOrder = 1, RoyaltyPercentage = 100 }
            );

            await db.Stores.AddRangeAsync(
                new Store { StoreId = "7066", StoreName = "Barnum's", Address = "567 Pasadena Ave.", City = "Tustin", State = "CA", Zip = "92789" },
                new Store { StoreId = "7067", StoreName = "News & Brews", Address = "577 First St.", City = "Los Gatos", State = "CA", Zip = "96745" },
                new Store { StoreId = "7131", StoreName = "Doc-U-Mat: Quality Laundry and Books", Address = "24-A Avogadro Way", City = "Remulade", State = "WA", Zip = "98014" },
                new Store { StoreId = "8042", StoreName = "Bookbeat", Address = "679 Carson St.", City = "Portland", State = "OR", Zip = "89076" },
                new Store { StoreId = "6380", StoreName = "Eric the Read Books", Address = "788 Catamaugus Ave.", City = "Seattle", State = "WA", Zip = "98056" },
                new Store { StoreId = "7896", StoreName = "Fricative Bookshop", Address = "89 Madison St.", City = "Fremont", State = "CA", Zip = "90019" }
            );

            await db.Set<Sale>().AddRangeAsync(
                new Sale { StoreId = "7066", OrderNumber = "QA7442.3", OrderDate = new DateTime(1994, 9, 13), Quantity = 75, PayTerms = "ON invoice", TitleId = "PS2091" },
                new Sale { StoreId = "7067", OrderNumber = "D4482", OrderDate = new DateTime(1994, 9, 14), Quantity = 10, PayTerms = "Net 60", TitleId = "PS2091" },
                new Sale { StoreId = "7131", OrderNumber = "N914008", OrderDate = new DateTime(1994, 9, 14), Quantity = 20, PayTerms = "Net 30", TitleId = "PS2091" },
                new Sale { StoreId = "7131", OrderNumber = "N914014", OrderDate = new DateTime(1994, 9, 14), Quantity = 25, PayTerms = "Net 30", TitleId = "MC3021" },
                new Sale { StoreId = "8042", OrderNumber = "423LL922", OrderDate = new DateTime(1994, 9, 14), Quantity = 15, PayTerms = "ON invoice", TitleId = "MC3021" },
                new Sale { StoreId = "8042", OrderNumber = "423LL930", OrderDate = new DateTime(1994, 9, 14), Quantity = 10, PayTerms = "ON invoice", TitleId = "BU1032" },
                new Sale { StoreId = "6380", OrderNumber = "722a", OrderDate = new DateTime(1994, 9, 13), Quantity = 3, PayTerms = "Net 60", TitleId = "PS2091" },
                new Sale { StoreId = "6380", OrderNumber = "6871", OrderDate = new DateTime(1994, 9, 14), Quantity = 5, PayTerms = "Net 60", TitleId = "BU1032" },
                new Sale { StoreId = "8042", OrderNumber = "P723", OrderDate = new DateTime(1993, 3, 11), Quantity = 25, PayTerms = "Net 30", TitleId = "BU1111" },
                new Sale { StoreId = "7896", OrderNumber = "X999", OrderDate = new DateTime(1993, 2, 21), Quantity = 35, PayTerms = "ON invoice", TitleId = "BU2075" },
                new Sale { StoreId = "7896", OrderNumber = "QQ2299", OrderDate = new DateTime(1993, 10, 28), Quantity = 15, PayTerms = "Net 60", TitleId = "BU7832" },
                new Sale { StoreId = "7896", OrderNumber = "TQ456", OrderDate = new DateTime(1993, 12, 12), Quantity = 10, PayTerms = "Net 60", TitleId = "MC2222" },
                new Sale { StoreId = "8042", OrderNumber = "QA879.1", OrderDate = new DateTime(1993, 5, 22), Quantity = 30, PayTerms = "Net 30", TitleId = "PC1035" },
                new Sale { StoreId = "7066", OrderNumber = "A2976", OrderDate = new DateTime(1993, 5, 24), Quantity = 50, PayTerms = "Net 30", TitleId = "PC8888" },
                new Sale { StoreId = "7131", OrderNumber = "P3087a", OrderDate = new DateTime(1993, 5, 29), Quantity = 20, PayTerms = "Net 60", TitleId = "PS1372" },
                new Sale { StoreId = "7131", OrderNumber = "P3087a", OrderDate = new DateTime(1993, 5, 29), Quantity = 25, PayTerms = "Net 60", TitleId = "PS2106" },
                new Sale { StoreId = "7131", OrderNumber = "P3087a", OrderDate = new DateTime(1993, 5, 29), Quantity = 15, PayTerms = "Net 60", TitleId = "PS3333" },
                new Sale { StoreId = "7131", OrderNumber = "P3087a", OrderDate = new DateTime(1993, 5, 29), Quantity = 25, PayTerms = "Net 60", TitleId = "PS7777" },
                new Sale { StoreId = "7067", OrderNumber = "P2121", OrderDate = new DateTime(1992, 6, 15), Quantity = 40, PayTerms = "Net 30", TitleId = "TC3218" },
                new Sale { StoreId = "7067", OrderNumber = "P2121", OrderDate = new DateTime(1992, 6, 15), Quantity = 20, PayTerms = "Net 30", TitleId = "TC4203" },
                new Sale { StoreId = "7067", OrderNumber = "P2121", OrderDate = new DateTime(1992, 6, 15), Quantity = 20, PayTerms = "Net 30", TitleId = "TC7777" }
            );

            await db.SaveChangesAsync();
        }
    }
}