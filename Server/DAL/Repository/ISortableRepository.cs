using BO.DTO.Requests;
using BO.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface ISortableRepository<TEntity>
	{
		/// <summary>
		/// permet de retourner une liste d'entité de façon paginée et triée
		/// </summary>
		/// <param name="PageRequestSortable"></param>
		/// <returns>Retourne une liste d'entité de façon paginée et triée</returns>
		
		
		//Task<TEntity> GetAsync(TEntity Entity);
	}
}
