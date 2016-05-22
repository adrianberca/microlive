using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microlive.DataLayer.BaseRepo;

namespace Microlive.DataLayer.Repositories
{
    public class CommentRepository : BaseRepoWithSinglePk<Comment>
    {
        public CommentRepository(Entities context) : base(context)
        {
        }

        public override async Task<Comment> CreateAsync(Comment comment, IList<string> navigationProperties = null)
        {
            foreach (var tag in comment.Tags)
            {
                Context.Entry(tag).State = EntityState.Unchanged;
            }

            return await base.CreateAsync(comment, navigationProperties);
        }

        public override async Task<Comment> UpdateAsync(Comment comment, IList<string> navigationProperties = null)
        {
            //TODO: check this
            foreach (var tag in comment.Tags)
            {
                Context.Entry(tag).State = EntityState.Unchanged;
            }

            return await base.UpdateAsync(comment, navigationProperties);
        }


        public async Task<IList<Comment>> GetAllByImageIdIdAsync(Guid imageId, IList<string> navigationProperties = null)
        {
            return await GetListAsync(comment => comment.ImageId == imageId, navigationProperties);
        }
    }
}
