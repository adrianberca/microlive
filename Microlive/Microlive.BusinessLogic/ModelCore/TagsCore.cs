using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microlive.BusinessLogic.BaseCore;
using Microlive.BusinessLogic.TypeManagement;
using Microlive.DataLayer;
using Microlive.DataLayer.BaseRepo;
using Microlive.DataLayer.Repositories;
using Tag = Microlive.Model.Tag;

namespace Microlive.BusinessLogic.ModelCore
{
    public class TagsCore : BaseCoreWithSinglePk<Tag, DataLayer.Tag>
    {
        private static TagsCore mInstance = null;

        public static TagsCore Instance()
        {
            return mInstance ?? (mInstance = new TagsCore());
        }

        internal override BaseRepo<DataLayer.Tag> GetRepoInstance(Entities context = null)
        {
            return new TagRepository(context ?? new Entities());
        }

        public async Task<IList<Tag>> GetAllByImageIdIdAsync(Guid imageId, IList<string> navigationProperties = null)
        {
            using (var tagRepository = (TagRepository)GetRepoInstance())
            {
                var tags = await tagRepository.GetAllByImageIdIdAsync(imageId, navigationProperties);
                if (tags == null)
                {
                    return new List<Tag>();
                }
                return tags.CopyTo<Tag>();
            }
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            return await base.UpdateAsync(tag);
        }
    }
}
