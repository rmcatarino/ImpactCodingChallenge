using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Domain.Interface
{
    public interface IRSSReaderService
    {
        IList<RSSItem> Load(string url);
    }
}
