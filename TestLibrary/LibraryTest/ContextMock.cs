using Infrastructure.Core.Context;
using Infrastructure.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LibraryTest
{
    public class ContextMock
    {
        private static DataContext context;
        public static DataContext Seed()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new DataContext(options);

            #region Seed
            SetEditorial();
            SetBook();
            context.SaveChanges();

            #endregion Seed

            return context;
        }

        private static void SetEditorial()
        {
            context.EditorialEntity.AddRange(new List<EditorialEntity>
            {
                new EditorialEntity
                {
                    IdEditorial=100,
                    Name="EditorialMock"
                },
                new EditorialEntity
                {
                    IdEditorial=101,
                    Name="EditorialMock_1"
                },
                 new EditorialEntity
                {
                    IdEditorial=102,
                    Name="EditorialMock_2"
                },
                     new EditorialEntity
                {
                    IdEditorial=103,
                    Name="EditorialMock_3"
                }
            });
        }

        private static void SetBook()
        {
            context.BookEntity.AddRange(new List<BookEntity>
            {
                new BookEntity
                {
                    Title="Mock_Title",
                    IdEditorial=100,
                    Author="MockAuthor",
                    Cost=100,
                    Date=DateTime.Now,
                    IdBook=100,
                    SuggestedPrice=200
                },
                new BookEntity
                {
                    Title="Mock_Title2",
                    IdEditorial=100,
                    Author="MockAuthor2",
                    Cost=200,
                    Date=DateTime.Now,
                    IdBook=101,
                    SuggestedPrice=400
                },
                new BookEntity
                {
                    Title="Mock_Title3",
                    IdEditorial=102,
                    Author="MockAuthor3",
                    Cost=400,
                    Date=DateTime.Now,
                    IdBook=102,
                    SuggestedPrice=800
                },
                new BookEntity
                {
                    Title="Mock_Title4",
                    IdEditorial=102,
                    Author="MockAuthor4",
                    Cost=800,
                    Date=DateTime.Now,
                    IdBook=103,
                    SuggestedPrice=1600
                }
            });
        }
    }
}
