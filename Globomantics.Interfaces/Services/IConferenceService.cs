using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.Models;

namespace Globomantics.Interfaces.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();

        Task<ConferenceModel> GetById(int id);

        Task Add(ConferenceModel conference);

        Task<StatisticsModel> GetStatistics();
    }
}
