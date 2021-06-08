using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface IgenericRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Permet de récupérer la liste des entités
		/// </summary>
		/// <returns>Retourne la liste des entités</returns>
		Task<IEnumerable<TEntity>> GetAllAsync();

		/// <summary>
		/// Permet de récupérer une entité par son Identifiant
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne une entité en particulier</returns>
		Task<TEntity> GetAsync(int id);

		/// <summary>
		/// Permet de mettre à jour une entité 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>Retourne un boolean en fonction du succes de la mise à jour</returns>
		Task<bool> UpdateAsync(TEntity entity);

		/// <summary>
		/// Permet d'ajouter une entité
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>Retourne la nouvelle entité</returns>
		Task<TEntity> InsertAsync(TEntity entity);

		/// <summary>
		/// Permet de supprimer une entité
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retourne un boolean en fonction du succes de la suppression</returns>
		Task<bool> DeleteAsync(int id);


		

	}
}
