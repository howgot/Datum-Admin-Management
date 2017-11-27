using Datum.Stock.Core;
using Xunit;
using Autofac;
using MongoDB.Driver;
using Datum.Stock.Core.Data;

namespace Datum.Stock.Tests.RepositoryTests
{

    public class BaseRepositoryTest : BaseTest
    {
        bool IsAsync = true;

        private readonly IRepository<TestEntity> _repository;

        public BaseRepositoryTest()
        {
            _repository = container.Resolve<IRepository<TestEntity>>();
        }

        [Fact]
        public void Should_Add_Item()
        {
            var newItem = new TestEntity()
            {
                Title = "Hello World!"
            };

            //Insert 
            if (IsAsync)
                _repository.InsertAsync(newItem).Wait();
            else
                _repository.Insert(newItem);

            //ID check
            Assert.True(!string.IsNullOrWhiteSpace(newItem.Id));
        }

        [Fact]
        public void Should_Update_Item()
        {

            var newItem = new TestEntity()
            {
                Title = "Hello"
            };

            //Insert 
            if (IsAsync)
                _repository.InsertAsync(newItem).Wait();
            else
                _repository.Insert(newItem);

            //ID check
            Assert.True(!string.IsNullOrWhiteSpace(newItem.Id));

            //Update
            var updateDefinition = Builders<TestEntity>.Update.Set(e => e.Title, "Hello World!");
            _repository.UpdateOneById(newItem.Id, updateDefinition);

            //Get updated entity
            if (IsAsync)
            {
                var task = _repository.GetOneByIdAsync(newItem.Id);
                task.Wait();
                newItem = task.Result;
            }
            else
                newItem = _repository.GetOneById(newItem.Id);

            //Title Check
            Assert.Equal("Hello World!", newItem.Title);

            //Modified Check
            Assert.True(newItem.Modified >= newItem.Created);
        }
    }
}
