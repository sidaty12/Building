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
        void AddProperty(Property property);
        void DeletePropertyByIdAsync(int id);
    }
}
