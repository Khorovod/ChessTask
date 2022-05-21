using System.Collections.Generic;
using System.Drawing;

namespace Interface
{
    public enum ChessmanType
    {
        Rook, // ладья
        Bishop, // слон
        Knight // конь
    }
    public interface IChessman
    {
        List<Point> GetMoves();
    }
}
