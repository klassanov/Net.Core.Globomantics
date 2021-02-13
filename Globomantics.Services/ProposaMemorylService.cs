using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;

namespace Globomantics.Services
{
    public class ProposaMemorylService : IProposalService
    {
        private int maxProposalId;
        private readonly List<ProposalModel> proposals;

        public ProposaMemorylService()
        {
            this.proposals = new List<ProposalModel>()
            {
                new ProposalModel{Id=1, Speaker="Adam Freeman", ConferenceId=1, Title=".NET 5 Talk"},
                new ProposalModel{Id=2, Speaker="Toma Brusarski", ConferenceId=1, Title=".How do we do it at Fourth"}
            };

            this.maxProposalId = this.proposals.Max(x => x.Id);
        }

        public Task Add(ProposalModel proposal)
        {
            proposal.Id = ++maxProposalId;
            this.proposals.Add(proposal);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = this.proposals.Single(x => x.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => this.proposals.Where(x => x.ConferenceId == conferenceId).AsEnumerable());
        }
    }
}
