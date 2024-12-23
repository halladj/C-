﻿namespace TheEmployeeAPI.Tests;

using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using TheEmployeeAPI;


public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


   [Fact]
public async Task GetEmployeeById_ReturnsOkResult()
{
    var client = _factory.CreateClient();
    var response = await client.GetAsync("/employees/1");

    response.EnsureSuccessStatusCode();
}

[Fact]
public async Task CreateEmployee_ReturnsCreatedResult()
{
    var client = _factory.CreateClient();
    var response = await client.PostAsJsonAsync("/employees", new Employee { FirstName = "John", LastName = "Doe", SocialSecurityNumber="123-45-3445" });

    response.EnsureSuccessStatusCode();
}

[Fact]
public async Task CreateEmployee_ReturnsBadRequestResult()
{
    var client = _factory.CreateClient();
    var response = await client.PostAsJsonAsync("/employees", new{});

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
}

[Fact]
public async Task UpdateEmployee_ReturnsOkResult()
{
    var client = _factory.CreateClient();
    var response = await client.PutAsJsonAsync("/employees/1", new Employee { FirstName = "John", LastName = "Doe", SocialSecurityNumber="123-45-3445" });

    response.EnsureSuccessStatusCode();
}
}