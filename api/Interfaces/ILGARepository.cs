using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.LGA;

namespace api.Interfaces
{
    public interface ILGARepository
    {
        Task<List<LgaDTO>> GetLGAByStateIDAsync(int stateId);
    }
}