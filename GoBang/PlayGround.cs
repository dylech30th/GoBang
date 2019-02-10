using System;
using System.Text;

namespace GoBang
{
    public class PlayGround
    {
        private readonly Point[,] _chessBoard = new Point[15, 15];
        private const char BlackChessman = 'B';
        private const char WhiteChessman = 'W';
        private const char Empty = '—';
        public bool IsWhiteGo;

        public PlayGround()
        {
            RandomizeFirst();
            for (var i = 0; i < 15; i++)
                for (var j = 0; j < 15; j++)
                    _chessBoard[i, j] = new Point(i, j, Chessman.Empty);
        }

        private void RandomizeFirst()
        {
            var rnd = new Random().Next(2);
            IsWhiteGo = rnd == 0;
        }

        public Winner Check(Point coordinate)
        {
            var checker = new Checker(_chessBoard);
            return checker.Check(coordinate);
        }

        public string GetChessBoard()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 14; i >= 0; i--)
            {
                for (var j = 0; j < 15; j++)
                    stringBuilder.Append(_chessBoard[j, i].Chessman == Chessman.Black
                        ? BlackChessman
                        : _chessBoard[j, i].Chessman == Chessman.White
                            ? WhiteChessman
                            : Empty);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        public void WhiteGo(int x, int y)
        {
            IsWhiteGo = false;
            if (_chessBoard[x, y].Chessman == Chessman.Empty)
            {
                _chessBoard[x, y] = new Point(x, y, Chessman.White);
            }
        }

        public void BlackGo(int x, int y)
        {
            IsWhiteGo = true;
            if (_chessBoard[x, y].Chessman == Chessman.Empty)
            {
                _chessBoard[x, y] = new Point(x, y, Chessman.Black);
            }
        }

        public bool CheckChessBoardIsFull()
        {
            for (var i = 0; i < 15; i++)
                for (var j = 0; j < 15; j++)
                    if (_chessBoard[i, j].Chessman == Chessman.Empty)
                        return false;
            return true;
        }

        public bool Go(int x, int y)
        {
            if (CheckChessBoardIsFull())
            {
                Console.WriteLine("和棋");
            }
            if (IsWhiteGo)
                WhiteGo(x, y);
            else
                BlackGo(x, y);
            if (Check(_chessBoard.GetPoint(x, y)) == Winner.Black)
            {
                Console.WriteLine("黑方获胜");
                return true;
            }
            if (Check(_chessBoard.GetPoint(x, y)) == Winner.White)
            {
                Console.WriteLine("白方获胜");
                return true;
            }

            return false;
        }

        public static void Main(string[] args)
        {
            var playGround = new PlayGround();
            while (true)
            {
                Console.WriteLine(playGround.GetChessBoard());
                Console.WriteLine(playGround.IsWhiteGo ? "白方走子" : "黑方走子");
                Console.WriteLine("请输入X");
                var x = Console.ReadLine();
                Console.WriteLine("请输入Y");
                var y = Console.ReadLine();
                if (!x.IsNumber() || !y.IsNumber() || x == null || y == null)
                {
                    Console.WriteLine("输入格式非法");
                    continue;
                }
                if (playGround.Go(int.Parse(x), int.Parse(y)))
                {
                    break;
                }
            }
            Console.WriteLine("游戏结束");
            Console.ReadKey();
        }
    }
}
