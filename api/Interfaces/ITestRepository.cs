using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Test;
using api.Models;

namespace api.Interfaces
{
    public interface ITestRepository
    {
        Task<TestTable> InsertTest(TestForCreationDTO test);
    }
}