using Moq;
using OrderManagement.Core;
using OrderManagement.Core.Models;
using OrderManagement.Core.Repositories;
using OrderManagement.Core.Services;
using OrderManagement.Services;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void GetByIDAsync_Returns_Supplier()
        {
            //Arrange
            var supplierID = 1;
            var expected = "Supplier 1";
            var supplier = new Supplier() { Name = expected, ID = 1 };

            var productRepositoryMock = new Mock<ISupplierRepository>();
            productRepositoryMock.Setup(m => m.GetSupplierByIDAsync(supplierID)).Returns(Task.FromResult(supplier)).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Suppliers).Returns(productRepositoryMock.Object);

            ISupplierService sut = new SupplierService(unitOfWorkMock.Object);

            //Act
            var actual = await sut.GetSupplierByIDAsync(supplierID);

            //Assert
            productRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.NotNull(actual);//assert that a result was returned
            Assert.Equal(expected, actual.Name);//assert that actual result was as expected
        }
    }
}