using Ucommerce.Content;

namespace RunningUCommerce.Content
{
    public class IntegrationTestImageService : IImageService
    {
        Ucommerce.Content.Content IImageService.GetImage(string id)
        {
            return new Ucommerce.Content.Content
            {
                Name = "Image",
                Url = "Url"
            };
        }
    }
}