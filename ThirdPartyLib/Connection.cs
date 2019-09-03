using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftShimTesting
{
    public class Connection
    {
        internal Connection()
        {
        }

        public string PublicProp { get; set; }

        public string GetSettings()
        {
            return "pub call";
        }

        private string GetSecret()
        {
            return "pri call";
        }
    }
}
