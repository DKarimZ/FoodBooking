using BO.Entity;
using DAL.UOW;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Responses;
using BO.DTO.Requests;

namespace BLL.Services
{
	/// <summary>
	/// permet de fournir les services de gestion de la restauration
	/// </summary>
	 
	public class RestaurationService : IRestaurationService
	{
		/// <summary>
		/// Permet d'uiliser l'Interface Unit of Work
		/// </summary>
		private readonly IUnitOfWork _db;

		public RestaurationService(IUnitOfWork unitOfWork)
		{
			_db = unitOfWork;
		}

		// Methodes liées aux services de gestion des menus
		#region Menu
		public async Task <List<Service>> GetAllServices()
		{
			//Utilisation de la méthode GetAllAsync du repository IMenurepository
			IServiceRepository _menus = _db.GetRepository<IServiceRepository>();
			IEnumerable<Service> menus = await _menus.GetAllAsync();

			return menus.ToList();

		}
		public async Task<Service> GetServiceById(int IdMenu)
		{
			IServiceRepository _menus = _db.GetRepository<IServiceRepository>();
			return await _menus.GetAsync(IdMenu);
		}
		public async Task<Service> CreateService(Service newMenu)
		{
			//La methode InsertAsync est appelé dans une transaction
			_db.BeginTransaction();
			
			IServiceRepository _menus = _db.GetRepository<IServiceRepository>();
			Service nouvMenu = await _menus.InsertAsync(newMenu);
			//if(nouvMenu.Plats[0]!= null && nouvMenu.Plats[1]!= null && nouvMenu.Plats[2]!=null) 
				_db.Commit();
			return nouvMenu;

		}
		public async Task<Service> UpdateService(Service menuToUpdate)
		{
			_db.BeginTransaction();
			IServiceRepository _menus = _db.GetRepository<IServiceRepository>();
			try
			{
				//Ici on teste si la methode UpdateAsync a fonctionné (elle renvoie le boolean isModified)

				bool isModified = await _menus.UpdateAsync(menuToUpdate);
				_db.Commit();

				if (isModified)
				{
					//Si ça fonctionne on retourne le menu modifié
					return await Task.FromResult(menuToUpdate);
				}

				else
				{
					//Sinon on retourne null
					return null;
				}
			}
			catch 
			{
				return null;
				
			}

		}
		public async Task<bool> RemoveService(int IdService)
		{
			//La methode DeleteAsync est appelée dans une transaction
			_db.BeginTransaction();
			IServiceRepository _service = _db.GetRepository<IServiceRepository>();
			bool isDeleted = await _service.DeleteAsync(IdService);
			_db.Commit();
			return isDeleted;


		}

		#endregion

		// Methodes liées aux services de gestion des plats
		#region Plat
		public async Task<PageResponse<Plat>> GetAllPlats(PageRequest pageRequest)
		{
			//Utilisation de la méthode GetAllAsync du repository IPlatrepository

			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			return await _plats.GetAllAsync(pageRequest);

			
		}
		public async Task<List<Plat>> GetAllPlats()
		{
			//Utilisation de la méthode GetAllAsync du repository IMenurepository
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			IEnumerable<Plat> plats = await _plats.GetAllAsync();

			return plats.ToList();

		}




		public async Task<Plat> GetPlatById(int IdPlat)
		{
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			return await _plats.GetAsync(IdPlat);
		}
		public async Task<Plat> CreatePlat(Plat newPlat)
		{
			//La methode InsertAsync est appelé dans une transaction
			_db.BeginTransaction();
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			Plat nouvPlat = await _plats.InsertAsync(newPlat);
			_db.Commit();
			return nouvPlat;
		}

		public async Task<List<Plat>> GetAllPlatsByType(int idType)
		{
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			return (await _plats.GetAllThePlatsByTypePlat(idType)).ToList();
	}



		public async Task<Plat> UpdatePlat(Plat platToUpdate)
		{
			_db.BeginTransaction();
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			try
			{
				//Ici on teste si la methode UpdateAsync a fonctionné (elle renvoie le boolean isModified)
				bool isModified = await _plats.UpdateAsync(platToUpdate);
				_db.Commit();

				if (isModified)
				{
					//Si cela fonctionne on retourne le plat modifié
					return await Task.FromResult(platToUpdate);
				}

				else
				{
					//sinon on retourne null
					return null;
				}
			}
			catch
			{
				return null;

			}

		}
		public async Task<bool> RemovePlat(int IdPlat)
		{
			//La methode DeleteAsync est appeléee dans une transaction
			_db.BeginTransaction();
			IPlatRepository _plats = _db.GetRepository<IPlatRepository>();
			bool isDeleted = await _plats.DeleteAsync(IdPlat);
			_db.Commit();
			return isDeleted;
		}

		#endregion

		// Methodes liées aux services de gestion des ingrédients
		#region Ingredients
		public async Task<PageResponse<Ingredient>> GetAllIngredients(PageRequest pageRequest)
		{
			//Utilisation de la méthode GetAllAsync du repository IIngredientrepository
			IIngredientRepository _ingredients = _db.GetRepository<IIngredientRepository>();
			return await _ingredients.GetAllAsync(pageRequest);
	
		}
		public async Task<Ingredient> GetIngredientById(int IdIngredient)
		{
			IIngredientRepository _ingredients = _db.GetRepository<IIngredientRepository>();
			return await _ingredients.GetAsync(IdIngredient);
		}
		public async Task<Ingredient> CreateIngredient(Ingredient newIngredient)
		{
			//LA methode InsertAsync est utilisée dans une transaction
			_db.BeginTransaction();
			IIngredientRepository _ingredient = _db.GetRepository<IIngredientRepository>();
			Ingredient nouvIngredient = await _ingredient.InsertAsync(newIngredient);
			_db.Commit();
			return nouvIngredient;
		}
		public async Task<Ingredient> UpdateIngredient(Ingredient ingredientToUpdate)
		{
			_db.BeginTransaction();
			IIngredientRepository _ingredient = _db.GetRepository<IIngredientRepository>();
			try
			{
				//Ici on teste si la methode UpdateAsync a fonctionné (elle renvoie le boolean isModified)
				bool isModified = await _ingredient.UpdateAsync(ingredientToUpdate);
				_db.Commit();

				if (isModified)
				{
					//Si cela fonctionne on renvoie l'ingredient modifié
					return await Task.FromResult(ingredientToUpdate);
				}

				else
				{
					//Sinon on retourne null
					return null;
				}
			}
			catch
			{
				return null;

			}

		}
		public async Task<bool> RemoveIngredient(int IdIngredient)
		{
			//La methode DeleteAsync est appelée dans une transaction
			_db.BeginTransaction();
			IIngredientRepository _ingredient = _db.GetRepository<IIngredientRepository>();
			bool isDeleted = await _ingredient.DeleteAsync(IdIngredient);
			_db.Commit();
			return isDeleted;
		}

		#endregion
	}
}
