﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;

namespace Globomantics.Services
{
    public class ConferenceApiService : IConferenceService
    {
        public Task Add(ConferenceModel conferenceModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ConferenceModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<StatisticsModel> GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}
