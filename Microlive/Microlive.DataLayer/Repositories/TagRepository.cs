using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microlive.DataLayer.BaseRepo;

namespace Microlive.DataLayer.Repositories
{
    public class TagRepository : BaseRepoWithSinglePk<Tag>
    {
        public TagRepository(Entities context) : base(context)
        {
        }

        public override async Task<Tag> CreateAsync(Tag tag, IList<string> navigationProperties = null)
        {
            return await base.CreateAsync(tag, navigationProperties);
        }

        public override async Task<Tag> UpdateAsync(Tag tag, IList<string> navigationProperties = null)
        {

            return await base.UpdateAsync(tag, navigationProperties);
        }


        public async Task<IList<Tag>> GetAllByImageIdIdAsync(Guid imageId, IList<string> navigationProperties = null)
        {
            return await GetListAsync(tag => tag.ImageId == imageId, navigationProperties);
        }
    }
}
