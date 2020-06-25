using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucommerce.Infrastructure.Globalization;

namespace RunningUCommerce.Globalization
{
    public class LanguageService : ILanguageService
    {
        public IList<Language> GetAllLanguages()
        {
            return new List<Language>()
            {
                new Language("en-US", "en-US")
            };
        }
    }
}
