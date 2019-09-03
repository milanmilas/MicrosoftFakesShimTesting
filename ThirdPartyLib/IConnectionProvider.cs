using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftShimTesting
{
    public interface IConnectionProvider
    {
        Connection GetConnection { get; set; }
    }
}
