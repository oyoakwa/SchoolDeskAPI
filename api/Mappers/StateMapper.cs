using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.States;
using api.Models;

namespace api.Mappers
{
    public static class StateMapper
    {
        public static StateDTO ToStateDTOFromSatate(this State state)
        {
            return new StateDTO
            {
                StateId = state.StateId,
                state = state.state
            };
        }
    }
}