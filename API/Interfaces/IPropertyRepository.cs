using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(string sellRent);
        Task<Property> GetPropertyDetailAsync(int id);
       Task<Property> GetPropertyByIdAsync(int id);

    Task<IEnumerable<Property>> GetUserPropertiesAsync(int? userId);

    void AddProperty(Property property);
        void DeletePropertyByIdAsync(int id);
    }
}
