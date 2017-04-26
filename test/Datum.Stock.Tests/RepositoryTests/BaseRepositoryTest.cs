using Datum.Stock.Core.Domain;
using Datum.Stock.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Autofac;
using Moq;
using Datum.Stock.Data.Interfaces;
using Datum.Stock.Data;
using Datum.Stock.Core.Entities;
using Datum.Stock.Core.Domain.Entities;

namespace Datum.Stock.Tests.RepositoryTests
{

    public class BaseRepositoryTest : BaseTest
    {
        private readonly IRepository<TestEntity> _repository;

        public BaseRepositoryTest()
        {
            _repository = container.Resolve<IRepository<TestEntity>>();
        }

        [Fact]
        public void Should_add_item()
        {
            var newItem = new TestEntity()
            {
                Title = "Hello World!"
            };

            _repository.Add(newItem);

            //ID check
            Assert.True(!string.IsNullOrWhiteSpace(newItem.Id));
        }
    }
}
