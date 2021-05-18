using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Requests;
using BO.DTO.Responses;


namespace DAL.Repository
{
	public interface IpageableRepository<TEntity>
	{
		/// <summary>
		/// Permet de récupérer une liste d'entité avec une pagination
		/// </summary>
		/// <param name="pageRequest"></param>
		/// <returns>Retourne une liste d'entité de façon paginée</returns>
		Task<PageResponse<TEntity>> GetAllAsync(PageRequest pageRequest);
	}

	
}
