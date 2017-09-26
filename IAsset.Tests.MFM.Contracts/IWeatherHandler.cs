using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAsset.Tests.MFM.Contracts
{
    public interface IWeatherHandler
    {
        string GetWeatherJSON(string country, string city, out string mode);
    }
}
