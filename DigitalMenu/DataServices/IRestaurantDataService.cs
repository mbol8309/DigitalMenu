using DigitalMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.DataServices
{
    public interface IRestaurantDataService
    {
        Task<List<Restaurant>> SearchAsync(string name);
    }
}
