using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Pot object must possess.
    /// //Flop,Turn,River
    /// </summary>
    public interface IPot
    {
        int Id { get; }
        decimal Size { get; }
    }
}