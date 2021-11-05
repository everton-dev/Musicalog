using Moq;
using Musicalog.Application.Services;
using Musicalog.Domain.Entities;
using Musicalog.Domain.Interfaces.Application;
using Musicalog.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Musicalog.Tests.Unit
{
    public class AlbumServiceTest
    {
        private readonly IAlbumService _serviceSuccess;
        private readonly IAlbumService _serviceError;
        private Mock<IAlbumRepository> _mockSuccessRepository;
        private Mock<IAlbumRepository> _mockErrorRepository;

        public AlbumServiceTest()
        {
            ConfigureSuccessMock();
            ConfigureErrorMock();

            _serviceSuccess = new AlbumService(_mockSuccessRepository.Object);
            _serviceError = new AlbumService(_mockErrorRepository.Object);
        }

        private void ConfigureSuccessMock()
        {
            var list = new List<Album>()
            {
                new Album() { Id = 1, Title = "Title 1", ArtistName = "ArtistName 1", TypeAlbumId = 1, Stock = 1 },
                new Album() { Id = 2, Title = "Title 2", ArtistName = "ArtistName 2", TypeAlbumId = 1, Stock = 2 },
                new Album() { Id = 3, Title = "Title 3", ArtistName = "ArtistName 3", TypeAlbumId = 1, Stock = 3 },
                new Album() { Id = 4, Title = "Title 4", ArtistName = "ArtistName 4", TypeAlbumId = 1, Stock = 4 },
                new Album() { Id = 5, Title = "Title 5", ArtistName = "ArtistName 5", TypeAlbumId = 1, Stock = 5 },
                new Album() { Id = 6, Title = "Title 6", ArtistName = "ArtistName 6", TypeAlbumId = 1, Stock = 6 },
            };

            _mockSuccessRepository = new Mock<IAlbumRepository>();
            _mockSuccessRepository.Setup(x => x.Update(It.IsAny<Album>())).Returns(1);
            _mockSuccessRepository.Setup(x => x.Insert(It.IsAny<Album>())).Returns(1);
            _mockSuccessRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(1);
            _mockSuccessRepository.Setup(x => x.GetAll()).Returns(list);
            _mockSuccessRepository.Setup(x => x.GetAllOrderByArtistName()).Returns(list.OrderBy(c => c.ArtistName).ToList());
            _mockSuccessRepository.Setup(x => x.GetAllOrderByTitle()).Returns(list.OrderBy(c => c.Title).ToList());
            _mockSuccessRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(list[0]);
        }

        private void ConfigureErrorMock()
        {
            var list = new List<Album>();

            _mockErrorRepository = new Mock<IAlbumRepository>();
            _mockErrorRepository.Setup(x => x.Update(It.IsAny<Album>())).Returns(0);
            _mockErrorRepository.Setup(x => x.Insert(It.IsAny<Album>())).Returns(0);
            _mockErrorRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(0);
            _mockErrorRepository.Setup(x => x.GetAll()).Returns(list);
            _mockErrorRepository.Setup(x => x.GetAllOrderByArtistName()).Returns(list.OrderBy(c => c.ArtistName).ToList());
            _mockErrorRepository.Setup(x => x.GetAllOrderByTitle()).Returns(list.OrderBy(c => c.Title).ToList());
            _mockErrorRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(default(Album));
        }

        [Fact]
        public void DeleteSuccess()
        {
            var result = _serviceSuccess.Delete(It.IsAny<int>());
            Assert.True(result.Success);
        }

        [Fact]
        public void GetAllSuccess()
        {
            var result = _serviceSuccess.GetAll();
            Assert.True(result.Success);
        }

        [Fact]
        public void GetAllByTypeOrderArtistNameSuccess()
        {
            var result = _serviceSuccess.GetAll("ArtistName");
            Assert.True(result.Success);
        }

        [Fact]
        public void GetAllByTypeOrderTitleSuccess()
        {
            var result = _serviceSuccess.GetAll("Title");
            Assert.True(result.Success);
        }

        [Fact]
        public void GetByIdSuccess()
        {
            var result = _serviceSuccess.GetById(It.IsAny<int>());
            Assert.True(result.Success);
        }

        [Fact]
        public void InsertSuccess()
        {
            var result = _serviceSuccess.Insert(It.IsAny<Album>());
            Assert.True(result.Success);
        }

        [Fact]
        public void UpdateSuccess()
        {
            var result = _serviceSuccess.Update(It.IsAny<Album>());
            Assert.True(result.Success);
        }

        [Fact]
        public void DeleteError()
        {
            var result = _serviceError.Delete(It.IsAny<int>());
            Assert.False(result.Success);
        }

        [Fact]
        public void GetAllError()
        {
            var result = _serviceError.GetAll();
            Assert.False(result.Success);
        }

        [Fact]
        public void GetAllByTypeOrderArtistNameError()
        {
            var result = _serviceError.GetAll("ArtistName");
            Assert.False(result.Success);
        }

        [Fact]
        public void GetAllByTypeOrderTitleError()
        {
            var result = _serviceError.GetAll("Title");
            Assert.False(result.Success);
        }

        [Fact]
        public void GetByIdError()
        {
            var result = _serviceError.GetById(It.IsAny<int>());
            Assert.False(result.Success);
        }

        [Fact]
        public void InsertError()
        {
            var result = _serviceError.Insert(It.IsAny<Album>());
            Assert.False(result.Success);
        }

        [Fact]
        public void UpdateError()
        {
            var result = _serviceError.Update(It.IsAny<Album>());
            Assert.False(result.Success);
        }
    }
}