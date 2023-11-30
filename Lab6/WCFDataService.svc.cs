using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Data.Services;
using System.ServiceModel;
using System.Text;
using System.Data.Services.Common;

namespace Lab6
{
    public class WCFDataService : DataService<WSSAAEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}
