using Application.Users.Commands;
using Application.Users.Queries;
using System.Net;

namespace Intsoft.Exam.IntegrationTests
{
	public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
	{
		private readonly HttpClient _httpClient;
		private readonly Guid _userId = Guid.Parse("b158fde2-fd7f-4e3f-98eb-2b248465aec9");

		public UserControllerTests(CustomWebApplicationFactory<Program> factory)
		{
			_httpClient = factory.CreateDefaultClient();
		}

		[Fact]
		public async Task Get_user_by_id_returns_expected_user()
		{
			string url = $"/api/user/{_userId}";

			var userDto = await _httpClient.GetFromJsonAsync<UserDto>(url);

			Assert.NotNull(userDto);
			Assert.Equal("Mohammad", userDto.FirstName);
		}
		[Fact]
		public async Task Create_adds_user_to_database()
		{
			string url = "/api/user";
			var createCommand = new CreateUserCommand("Hirad", "Ahmadi", "3278445555", "09103652902");
			var response = await _httpClient.PostAsJsonAsync(url, createCommand);

			Assert.NotNull(response);
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task Update_should_changes_user_info()
		{
			string url = "/api/user";
			var createCommand = new EditUserCommand(_userId, "Iman", "Rezaie", "3276581452", "09353652908");
			var response = await _httpClient.PostAsJsonAsync(url, createCommand);

			response.EnsureSuccessStatusCode();
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}
