using FloridaIguanaTracker.Api.Controllers;
using FloridaIguanaTracker.Application.Sightings;
using FloridaIguanaTracker.Contracts.Common;
using FloridaIguanaTracker.Contracts.Sightings;
using FloridaIguanaTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.UnitTests.Controllers
{
    public class SightingsControllerTests
    {
        private readonly Mock<ISightingRepository> _repositoryMock;
        private readonly SightingsController _controller;

        public SightingsControllerTests()
        {
            _repositoryMock = new Mock<ISightingRepository>();
            _controller = new SightingsController(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetById_WhenSightingExists_ReturnsOk()
        {
            // Arrange
            var sighting = new Sighting(
                DateTime.UtcNow,
                26.3683,
                -80.1289,
                "Boca Raton",
                "Test sighting");

            _repositoryMock
                .Setup(repository => repository.GetByIdAsync(
                    1,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(sighting);

            // Act
            var result = await _controller.GetById(
                1,
                CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetById_WhenSightingDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _repositoryMock
                .Setup(repository => repository.GetByIdAsync(
                    999,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((Sighting?)null);

            // Act
            var result = await _controller.GetById(
                999,
                CancellationToken.None);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_WhenPageIsZero_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetAll(
            page: 0,
            pageSize: 20,
            city: null,
            fromDate: null,
            toDate: null,
            search: null,
            cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_WhenPageSizeExceedsMaximum_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetAll(
            page: 1,
            pageSize: 101,
            city: null,
            fromDate: null,
            toDate: null,
            search: null,
            cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_WhenFromDateIsAfterToDate_ReturnsBadRequest()
        {
            // Arrange
            var fromDate = new DateTime(2026, 10, 9);
            var toDate = new DateTime(2026, 10, 1);

            // Act
            var result = await _controller.GetAll(
                page: 1,
                pageSize: 20,
                city: null,
                fromDate: fromDate,
                toDate: toDate,
                search: null,
                cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_WhenNoSightingsExist_ReturnsEmptyPagedResponse()
        {
            // Arrange
            _repositoryMock
                .Setup(repository => repository.GetPagedAsync(
                    It.IsAny<SightingQuery>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((
                (IReadOnlyList<Sighting>)Array.Empty<Sighting>(),
                0));

            // Act
            var result = await _controller.GetAll(
                page: 1,
                pageSize: 20,
                city: null,
                fromDate: null,
                toDate: null,
                search: null,
                cancellationToken: CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<PagedResponse<SightingResponse>>(
                okResult.Value);

            Assert.Empty(response.Items);
            Assert.Equal(0, response.TotalCount);
            Assert.Equal(0, response.TotalPages);
            Assert.Equal(1, response.Page);
            Assert.Equal(20, response.PageSize);
        }

        [Fact]
        public async Task GetAll_WhenSightingsExist_ReturnsPaginationMetadata()
        {
            // Arrange
            var sightings = new List<Sighting>
            {
                new(
                DateTime.UtcNow,
                26.3683,
                -80.1289,
                "Boca Raton",
                "Test sighting")
            };

            _repositoryMock
                .Setup(repository => repository.GetPagedAsync(
                    It.IsAny<SightingQuery>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(((IReadOnlyList<Sighting>)sightings, 41));

            // Act
            var result = await _controller.GetAll(
                page: 2,
                pageSize: 20,
                city: null,
                fromDate: null,
                toDate: null,
                search: null,
                cancellationToken: CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<PagedResponse<SightingResponse>>(
                okResult.Value);

            Assert.Single(response.Items);
            Assert.Equal(41, response.TotalCount);
            Assert.Equal(3, response.TotalPages);
            Assert.Equal(2, response.Page);
            Assert.Equal(20, response.PageSize);
        }
    }
}
