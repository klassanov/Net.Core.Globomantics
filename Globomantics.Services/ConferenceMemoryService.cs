using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;

namespace Globomantics.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private int maxConferenceId;
        private readonly List<ConferenceModel> conferences;

        public ConferenceMemoryService()
        {
            this.conferences = new List<ConferenceModel>(){
                new ConferenceModel { Id = 1, Name = "Pluralsight Conference", AtendeeTotal = 50, Location = "Varna" },
                new ConferenceModel { Id = 2, Name = "Geek Conference", AtendeeTotal = 70, Location = "Sofia" }
            };

            this.maxConferenceId = conferences.Max(c => c.Id);
        }

        public Task Add(ConferenceModel conference)
        {
            conference.Id = ++this.maxConferenceId;
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
                    NumberOfAtendees = this.conferences.Sum(c => c.AtendeeTotal),
                    AverageConferenceAtendees = this.conferences.Average(c => c.AtendeeTotal)
                };
            });
        }
    }
}
