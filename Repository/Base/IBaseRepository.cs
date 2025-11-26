using Payaka.Domain.Base;
using System.Linq.Expressions;

namespace Payaka.Infrastructure.Repository.Base
{
    /// <summary>
    /// Définit les opérations de base pour un dépôt (repository) générique.
    /// Permet de récupérer les entités à partir d'un identifiant ou via des filtres.
    /// </summary>
    /// <typeparam name="T">Type de l'entité, doit hériter de <see cref="BaseEntity"/>.</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);
    }
}
