using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Country;

namespace api.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<CountryDTO>> GetCountriesAsync();
    }
}