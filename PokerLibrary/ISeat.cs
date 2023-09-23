using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Board object must possess.
    /// //Anything else can be calculated from this.
    /// </summary>
    public interface ISeat
    {
        int Id { get; }
    }
}