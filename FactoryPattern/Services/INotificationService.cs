﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Services
{
    public interface INotificationService
    {
        void Send(string message);
    }

}
