using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;

namespace Globomantics.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private static int maxConferenceId;
        private static readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel { Id = 1, Name = "Pluralsight Conference", AtendeeTotal = 50, Location = "Varna" });
            conferences.Add(new ConferenceModel { Id = 2, Name = "Geek Conference", AtendeeTotal = 70, Location = "Sofia" });
            maxConferenceId = conferences.Max(c => c.Id);
        }

        public Task Add(ConferenceModel conference)
        {
            conference.Id = ++maxConferenceId;
            conferences.Add(conference);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.FirstOrDefault(c => c.Id == id));
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    NumberOfAtendees = conferences.Sum(c => c.AtendeeTotal),
                    AverageConferenceAtendees = conferences.Average(c => c.AtendeeTotal)
                };
            });
        }
    }
}
