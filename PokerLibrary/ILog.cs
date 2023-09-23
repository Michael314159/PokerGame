using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Log object must possess.
    /// </summary>
    public interface ILog
    {
        FileStream Filestream { get; }  
        void Log(string message);
    }
}