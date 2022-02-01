using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Utilitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
	[CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.Equal(true, result.IsSuccess);
            //Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.Equal(false, result.IsSuccess);
            //Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public async Task TestGetUsersAsync()
        {
            StreamFile file = new StreamFile();
            String path = @"F:\Proyectos\Git\adolfredo87\ParamoTech\Sat.Recruitment.Api\Files\Users.json";
            file.CrearArchivo(path);

            var context = new Sat.Recruitment.Api.Data.ApplicationDbContext();
			context.Users.Add(new User() { Name = "Jamie Lanister", Email = "jaime@got.com", Address = "Desembarco del rey", Phone = "+54 11 53545445", UserType = "Normal", Money = decimal.Parse("54.62") });
			context.Users.Add(new User() { Name = "Cersei Lanister", Email = "cersei@got.com", Address = "Desembarco del rey", Phone = "+54 11 74853124", UserType = "Premium", Money = decimal.Parse("75.23") });
			await context.SaveChangesAsync();

			var userController = new UsersController();
            var result = await userController.GetUsersAsync();

            Assert.Equal(2, result.Count);
        }
    }
}
