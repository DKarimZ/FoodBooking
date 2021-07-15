using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO;
using BO.Entity;

namespace BLLC.Services
{
	public interface IFournisseurService
	{
		Task<CommandDTO> GetCommande();
	}
}
