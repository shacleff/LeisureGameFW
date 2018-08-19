using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoeyGame
{
    public interface ILogOutput
    {
        void Log(LogData logData);
        void Close();
    }
}
