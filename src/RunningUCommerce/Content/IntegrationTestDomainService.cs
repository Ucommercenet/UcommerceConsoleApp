﻿using System.Collections.Generic;
using Ucommerce.Content;

namespace RunningUCommerce.Content
{
    public class IntegrationTestDomainService : IDomainService
    {
        public IEnumerable<Domain> GetDomains()
        {
            return new List<Domain>()
            {

            };
        }

        public Domain GetDomain(string domainName)
        {
            return null;
        }

        public Domain GetCurrentDomain()
        {
            return null;
        }
    }
}