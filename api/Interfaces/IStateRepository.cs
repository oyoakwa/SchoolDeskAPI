using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.States;
using api.Models;

namespace api.Interfaces
{
    public interface IStateRepository
    {
        Task<List<StateDTO>> GetStateByCountryIDAsync(int countryId);
        //Task<State?> CreateAsync(ArmsForCreationDTO armsDTO);
    }
}