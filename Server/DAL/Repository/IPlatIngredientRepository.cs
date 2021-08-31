using BO.Entity;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface IPlatIngredientRepository
	{
		Task<PlatIngredient> InsertAsync( PlatIngredient platIngredientToAdd);
		Task<PlatIngredient> GetAsync(int id);
	}
}