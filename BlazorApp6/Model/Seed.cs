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
            if (await db.Authors.AnyAsync() || await db.Titles.AnyAsync())
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

            await db.SaveChangesAsync();
        }
    }
}