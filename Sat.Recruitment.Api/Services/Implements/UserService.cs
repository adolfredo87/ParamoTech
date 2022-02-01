using Sat.Recruitment.Api.Data.Repositories.Interfaces;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services.Interfaces;
using Sat.Recruitment.Api.Utilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.Implements
{
	public class UserService : GenericService<User>, IUserService
	{
		private IUserRepository _userRepository; private StreamFile sf;
		private List<Sat.Recruitment.Api.Models.User> _users;

		public UserService(IUserRepository userRepository) : base(userRepository)
		{
			this._userRepository = userRepository; sf = new StreamFile(); _users = new List<User>();
		}

		public List<User> ObtenerListadoUsuarios()
		{
			return _userRepository.Listar().ToList();
		}

		public void Create(User user) 
		{
			// Se guarda en el Modelo
			_userRepository.Agregar(user);
		}

		public Boolean EsDuplicado(User usuNew, List<User> users)
		{
			var isDuplicated = false;
			foreach (var user in users)
			{
				if (user.Email == usuNew.Email || user.Phone == usuNew.Phone)
				{
					isDuplicated = true;
				}
				else if (user.Name == usuNew.Name)
				{
					if (user.Address == usuNew.Address)
					{
						isDuplicated = true;
					}
				}
			}
			return isDuplicated;
		}

		private User RefactorUser(string name, string email, string address, string phone, string userType, string money)
		{
			User user = new User();
			var usr = user.refactorizarUsuario(name, email, address, phone, userType, money);
			return usr;
		}

		public Task<Result> RespuestaResult(string name, string email, string address, string phone, string userType, string money)
		{
			try
			{
				User usuNew = RefactorUser(name, email, address, phone, userType, money);
				_users = sf.RecorreUserFile();
				sf.CargarDatosJson(_users);
				if (!this.EsDuplicado(usuNew, _users))
				{
					this.Create(usuNew);

					return Task.FromResult(new Result()
					{
						IsSuccess = true,
						Errors = "User Created"
					});
				}
				else
				{
					return Task.FromResult(new Result()
					{
						IsSuccess = false,
						Errors = "The user is duplicated"
					});
				}
			}
			catch (Exception ex)
			{
				return Task.FromResult(new Result()
				{
					IsSuccess = false,
					Errors = "The user is duplicated"
				});
			}

			return Task.FromResult(new Result()
			{
				IsSuccess = true,
				Errors = "User Created"
			});
		}
	}
}
