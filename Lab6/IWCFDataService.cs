﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab6
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWCFDataService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWCFDataService
    {
        [OperationContract]
        void DoWork();
    }
}
