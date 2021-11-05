using FluentAssertions;
using Musicalog.Domain.Entities;
using Musicalog.Tests.Integrated.Fixtures;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Musicalog.Tests.Integrated
{
    public class AlbumControllerTest
    {
        private readonly TestContext _testContext;

        public AlbumControllerTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Album_GetAll_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/album/getall");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_GetAll_OrderByArtistName_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/album/getall/ArtistName");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_GetAll_OrderByTitle_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/album/getall/Title");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_GetById_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/album/getbyid/1");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_Create_ReturnsOkResponse()
        {
            var album = new Album() { Title = "Title xUnit", ArtistName = "ArtistName xUnit", TypeAlbumId = 2, Stock = 3 };
            var response = await _testContext.Client.PostAsJsonAsync("/api/album/create", album);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_Edit_ReturnsOkResponse()
        {
            var album = new Album() { Id = 12, Title = "Title xUnit Update", ArtistName = "ArtistName xUnit Update", TypeAlbumId = 1, Stock = 6 };
            var response = await _testContext.Client.PutAsJsonAsync("/api/album/edit", album);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Album_Delete_ReturnsOkResponse()
        {
            var response = await _testContext.Client.DeleteAsync("/api/album/delete/12");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
