using System.Collections.Generic;

using IAsset.Tests.MFM.Contracts;


namespace IAsset.Tests.MFM.Classes
{
    public class HomeViewModel : IHomeViewModel
    {
        public IDictionary<string,string> Countries { get ; set; }
    }
}
