﻿using System.Threading.Tasks;
using BN.Models;

namespace BN.Logic.Interfaces
{
    public interface IResortInfrastructureProvider
    {
        Task<ResortInfrastructure> GetResortInfrastructure();
    }
}