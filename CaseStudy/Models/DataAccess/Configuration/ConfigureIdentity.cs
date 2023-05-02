using Microsoft.AspNetCore.Identity;

namespace CaseStudy.Models.DataAccess.Configuration
{
	public class ConfigureIdentity
	{
		public static async Task CreateAdminUserAsync(IServiceProvider provider)
		{
			var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = provider.GetRequiredService<UserManager<User>>();

			string username = "admin";
			string password = "P@ssw0rd";
			string rolename = "Admin";

			// if role doesnt exist, create it
			if (await roleManager.FindByNameAsync(rolename) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(rolename));
			}

			// if username doesn't exist, create it and add to role
			if (await userManager.FindByNameAsync(username) == null)
			{
				User user = new User { UserName = username };
				var result = await userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, rolename);
				}
			}
		}
	}
}
