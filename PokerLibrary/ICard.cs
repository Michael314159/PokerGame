using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Card object must possess.
    /// //Anything else can be calculated from this.
    /// </summary>
    public interface ICard
    {
        int Id { get; }
    }
}
