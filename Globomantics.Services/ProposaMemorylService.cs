using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;

namespace Globomantics.Services
{
    public class ProposaMemorylService : IProposalService
    {
        public Task Add(ProposalModel proposal)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            throw new System.NotImplementedException();
        }
    }
}
