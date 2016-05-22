using System.Collections.Generic;
using System.Threading.Tasks;
using Microlive.BusinessLogic.BaseCore;
using Microlive.BusinessLogic.TypeManagement;
using Microlive.DataLayer;
using Microlive.DataLayer.BaseRepo;
using Microlive.DataLayer.Repositories;
using Image = Microlive.Model.Image;

namespace Microlive.BusinessLogic.ModelCore
{
        public class ImageCore : BaseCoreWithSinglePk<Image, DataLayer.Image>
        {
            private static ImageCore mInstance = null;

            public static ImageCore Instance()
            {
                return mInstance ?? (mInstance = new ImageCore());
            }

            internal override BaseRepo<DataLayer.Image> GetRepoInstance(Entities context = null)
            {
                return new ImageRepository(context ?? new Entities());
            }

        public async Task<IList<Image>> GetAllByAspNetUserIdAsync(string aspNetUserId, IList<string> navigationProperties = null)
        {
            using (var imageRepository = (ImageRepository)GetRepoInstance())
            {
                var images = await imageRepository.GetAllByAspNetUserIdAsync(aspNetUserId, navigationProperties);
                if (images == null)
                {
                    return new List<Image>();
                }

                return images.CopyTo<Image>();
            }
        }

        public async Task<Image> UpdateAsync(Image image)
            {

                return await base.UpdateAsync(image);
            }
        }
}
