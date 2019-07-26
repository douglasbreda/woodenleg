using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Moq;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Infra.Data.Data;
using WoodenLeg.Infra.Data.Repositories;
using WoodenLeg.Infra.Data.Test.DataTest;
using Xunit;

namespace WoodenLeg.Infra.Data.Test.Repositories
{
    public class RepositoryBaseTest
    {
        #region [Attributes]

        private CollectionGenerator _collectionGenerator = null;

        #endregion

        #region [Constructor]

        public RepositoryBaseTest()
        {
            _collectionGenerator = new CollectionGenerator();
        }

        #endregion

        #region [Tests]

        [Fact]
        public async void Create_Test()
        {
            var mockBase = new Mock<IMongoAccess>();
            TestEntity testEntity = _collectionGenerator.CreateSingleTestEntity();

            mockBase.Setup( x => x.InsertOne( null, testEntity ) ).Verifiable();

            RepositoryBase<TestEntity> repositoryBase = new RepositoryBase<TestEntity>();
            repositoryBase.MongoAccess = mockBase.Object;

            string returnedValue = await repositoryBase.Create( testEntity );

            mockBase.Verify();

            Assert.Equal( string.Empty, returnedValue );
        }

        [Fact]
        public async void Create_Test_Null()
        {
            var mockBase = new Mock<IMongoAccess>();

            string nullString = "The entity is null";

            TestEntity testEntity = null;

            mockBase.Setup( x => x.InsertOne( It.IsAny<IMongoCollection<TestEntity>>(), null ) );

            RepositoryBase<TestEntity> repositoryBase = new RepositoryBase<TestEntity>();
            repositoryBase.MongoAccess = mockBase.Object;

            string returnedValue = await repositoryBase.Create( testEntity );

            Assert.Equal( nullString, returnedValue );
        }

        [Fact]
        public async void Update_Test()
        {
            var mockBase = new Mock<IMongoAccess>();

            TestEntity testEntity = _collectionGenerator.CreateSingleTestEntity();

            mockBase.Setup( x => x.Update( It.IsAny<IMongoCollection<TestEntity>>(),
                                            testEntity, It.IsAny<FilterDefinition<TestEntity>>() ) );
                         

            RepositoryBase<TestEntity> repositoryBase = new RepositoryBase<TestEntity>();
            repositoryBase.MongoAccess = mockBase.Object;

            bool returnedValue = await repositoryBase.Update( testEntity );

            mockBase.Verify();

            Assert.False( returnedValue );
        }

        [Fact]
        public void Get_By_Id_Test()
        {
            var baseMock = new Mock<IRepositoryBase<TestEntity>>();

            TestEntity testEntity = _collectionGenerator.CreateSingleTestEntity();

            baseMock.Setup( x => x.GetById( testEntity.Id ) ).Returns( testEntity ).Verifiable();

            TestEntity returnedObject = baseMock.Object.GetById( testEntity.Id );

            baseMock.Verify();

            Assert.Equal( testEntity, returnedObject );
        }

        [Fact]
        public void Get_Test()
        {
            int numberOfInstances = 10;

            var baseMock = new Mock<IRepositoryBase<TestEntity>>();

            List<TestEntity> testEntity = _collectionGenerator.CreateListTestEntity( numberOfInstances );

            baseMock.Setup( x => x.Get() ).Returns( testEntity ).Verifiable();

            List<TestEntity> returnedList = baseMock.Object.Get().ToList();

            baseMock.Verify();

            Assert.Equal( numberOfInstances, returnedList.Count );

            Assert.Equal( testEntity[3], returnedList[3] );
        }

        #endregion
    }
}
