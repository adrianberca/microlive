using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microlive.DataLayer.BaseRepo;

namespace Microlive.DataLayer.Repositories
{
    public class ImageRepository : BaseRepoWithSinglePk<Image>
    {
        public ImageRepository(Entities context) : base(context)
        {
        }

        public override async Task<Image> CreateAsync(Image image, IList<string> navigationProperties = null)
        {
            foreach (var comment in image.Comments)
            {
                Context.Entry(comment).State = EntityState.Unchanged;
            }


            foreach (var tag in image.Tags)
            {
                Context.Entry(tag).State = EntityState.Unchanged;
            }

            return await base.CreateAsync(image, navigationProperties);
        }

        public override async Task<Image> UpdateAsync(Image image, IList<string> navigationProperties = null)
        {
            //TODO: check this
            foreach (var comment in image.Comments)
            {
                Context.Entry(comment).State = EntityState.Unchanged;
            }
            foreach (var tag in image.Tags)
            {
                Context.Entry(tag).State = EntityState.Unchanged;
            }
            return await base.UpdateAsync(image, navigationProperties);
        }


        public async Task<IList<Image>> GetAllByAspNetUserIdAsync(string aspNetUserId, IList<string> navigationProperties = null)
        {
            return await GetListAsync(image => image.AspNetUserId == aspNetUserId, navigationProperties);
        }
    }
}
