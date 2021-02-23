using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Interfaces
{
    public interface IDataShapeHelper<T>
    {
        IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString);
        Task<IEnumerable<Entity>> ShapeDataAsync(IEnumerable<T> entities, string fieldsString);
        Entity ShapeData(T entity, string fieldsString);
    }
}