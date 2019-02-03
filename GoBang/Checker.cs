using System;

namespace GoBang
{
    public class Checker
    {
        private readonly Point[,] _chessBoard;
        public Checker(Point[,] chessBoard)
        {
            _chessBoard = chessBoard;
        }

        public Winner Check(Point coordinate)
        {
            var verticalWinner = CheckVertical(coordinate);
            var horizontalWinner = CheckHorizontal(coordinate);
            var leadingDiagonalWinner = CheckLeadingDiagonal(coordinate);
            var diagonalWinner = CheckDiagonal(coordinate);
            if (verticalWinner != Winner.None)
                return verticalWinner;
            if (horizontalWinner != Winner.None)
                return horizontalWinner;
            if (leadingDiagonalWinner != Winner.None)
                return leadingDiagonalWinner;
            return diagonalWinner != Winner.None ? diagonalWinner : Winner.None;
        }

        private Winner CheckVertical(Point coordinate)
        {
            var white = 0;
            var black = 0;
            var up = coordinate;
            switch (coordinate.Chessman)
            {
                case Chessman.White:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X, up.Y + 1);
                    }

                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X, up.Y - 1);
                    }

                    break;
                case Chessman.Black:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X, up.Y + 1);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X, up.Y - 1);
                    }

                    break;
                case Chessman.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Winner.None;
        }

        private Winner CheckHorizontal(Point coordinate)
        {
            var white = 0;
            var black = 0;
            var up = coordinate;
            switch (coordinate.Chessman)
            {
                case Chessman.White:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.White)
                    {
                        white++;
                        if (white == 5)
                            return Winner.White;
                        if (up.X + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.White)
                    {
                        white++;
                        if (white == 5)
                            return Winner.White;
                        if (up.X - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y);
                    }

                    break;
                case Chessman.Black:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y);
                    }

                    break;
                case Chessman.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Winner.None;
        }

        private Winner CheckLeadingDiagonal(Point coordinate)
        {
            var white = 0;
            var black = 0;
            var up = coordinate;
            switch (coordinate.Chessman)
            {
                case Chessman.White:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.X - 1 < 0 || up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y + 1);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.X + 1 > 14 || up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y - 1);
                    }

                    break;
                case Chessman.Black:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X - 1 < 0 || up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y + 1);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X + 1 > 14 || up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y - 1);
                    }

                    break;
                case Chessman.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Winner.None;
        }

        private Winner CheckDiagonal(Point coordinate)
        {
            var white = 0;
            var black = 0;
            var up = coordinate;
            switch (coordinate.Chessman)
            {
                case Chessman.White:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.X + 1 > 14 || up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y + 1);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.White)
                    {
                        if (white == 5)
                            return Winner.White;
                        white++;
                        if (up.X - 1 < 0 || up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y - 1);
                    }

                    break;
                case Chessman.Black:
                    while (up.X <= 14 && up.Y <= 14 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X + 1 > 14 || up.Y + 1 > 14) break;
                        up = _chessBoard.GetPoint(up.X + 1, up.Y + 1);
                    }
                    up = coordinate;
                    while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.Black)
                    {
                        if (black == 5)
                            return Winner.Black;
                        black++;
                        if (up.X - 1 < 0 || up.Y - 1 < 0) break;
                        up = _chessBoard.GetPoint(up.X - 1, up.Y - 1);
                    }

                    break;
                case Chessman.Empty:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Winner.None;
        }
    }
}