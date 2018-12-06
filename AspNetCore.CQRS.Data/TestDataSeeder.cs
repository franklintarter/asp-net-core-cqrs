using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Data
{
    public class TestDataSeeder
    {
        public TestDataSeeder(DataContext dataContext)
        {
            var uow = new UnitOfWork(dataContext);

            var repository = new PersonRepository()
        }
    }
}
