using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// //The minimum a Player object must possess.
    /// //Flop,Turn,River
    /// </summary>
    public interface IPlayer
    {
        int Id { get; }
        decimal? TableStake {  get; }
        List<Card>? HoleCards { get; }
    }
}