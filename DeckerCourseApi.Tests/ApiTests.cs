using System.Net;
using FluentAssertions;

namespace DeckerCourseApi.Tests;

public class ApiTests
{
    [Fact]
    public async Task GivenGetRequestsToPodcastsEndpoint_ShouldReturnOkey()
    {
        var httpClient = new CustomWebApplicationFactory().CreateClient();
        var response = await httpClient.GetAsync("/podcasts");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}