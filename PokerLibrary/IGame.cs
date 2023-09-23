using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Game object must possess.
    /// </summary>
    public interface IGame
    {
        int Id { get; set; }
        List<ISeat> Seats { get; set; }
        List<ICard> Board { get; set; }
        List<IPot> Pots { get; set; }
        List<ICard> Deck { get; set; }

    }
}
