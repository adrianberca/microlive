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
using Comment = Microlive.Model.Comment;

namespace Microlive.BusinessLogic.ModelCore
{
    public class CommentsCore : BaseCoreWithSinglePk<Comment, DataLayer.Comment>
    {
        private static ImageCore mInstance = null;

        public static ImageCore Instance()
        {
            return mInstance ?? (mInstance = new ImageCore());
        }

        internal override BaseRepo<DataLayer.Comment> GetRepoInstance(Entities context = null)
        {
            return new CommentRepository(context ?? new Entities());
        }

        public async Task<IList<Comment>> GetAllByImageIdIdAsync(Guid imageId, IList<string> navigationProperties = null)
        {
            using (var commentRepository = (CommentRepository)GetRepoInstance())
            {
                var comments = await commentRepository.GetAllByImageIdIdAsync(imageId, navigationProperties);
                if (comments == null)
                {
                    return new List<Comment>();
                }

                return comments.CopyTo<Comment>();
            }
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {

            return await base.UpdateAsync(comment);
        }
    }
}
