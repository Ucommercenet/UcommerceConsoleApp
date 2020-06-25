using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucommerce.Content;

namespace RunningUCommerce.Content
{
    public class IntegrationTestContentService : IContentService
    {
        public Ucommerce.Content.Content GetContent(string contentId)
        {
            return new Ucommerce.Content.Content()
            {
                Icon = "",
                Id = "",
                Name = "",
                Url = ""
            };
        }
    }
}
