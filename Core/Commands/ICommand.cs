﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Execute();
    }
}
