using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucommerce.Infrastructure;
using Ucommerce.Search.Indexers;

namespace RunningUCommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Instance.Resolve<IScratchIndexer>().Index();
        }
    }
}
