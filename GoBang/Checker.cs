using System;

namespace GoBang
{
    public class Checker
    {
        private class Step
        {
            public Step(int leftX, int leftY, int rightX, int rightY)
            {
                LeftX = leftX;
                LeftY = leftY;
                RightX = rightX;
                RightY = rightY;
            }

            public int LeftX { get; }
            public int LeftY { get; }
            public int RightX { get; }
            public int RightY { get; }

        }

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
            return verticalWinner != Winner.None ? verticalWinner :
                horizontalWinner != Winner.None ? horizontalWinner :
                leadingDiagonalWinner != Winner.None ? leadingDiagonalWinner :
                diagonalWinner != Winner.None ? diagonalWinner : Winner.None;
        }

        private static Step ValidateStepLong(string method)
        {
            var validator = new Validator();
            var stepLeft = validator.Validate<LeftStep, Checker, Tuple<int, int>>(method, p => new Tuple<int, int>(p.StepX, p.StepY));
            var stepRight = validator.Validate<RightStep, Checker, Tuple<int, int>>(method, p => new Tuple<int, int>(p.StepX, p.StepY));
            return new Step(stepLeft.Item1, stepLeft.Item2, stepRight.Item1, stepRight.Item2);
        }

        private Winner Check(Point coordinate, Step stepLong, Chessman chessman)
        {
            var count = 0;
            var up = coordinate;
            // check the right side from self's coordinate
            while (up.X <= 14 && up.Y <= 14 && up.Chessman == chessman)
            {
                if (count == 5)
                    return chessman == Chessman.White ? Winner.White : Winner.Black;
                count++;
                try
                {
                    up = _chessBoard.GetPoint(up.X + stepLong.RightX, up.Y + stepLong.RightY);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            up = coordinate;
            // check the left side from self's coordinate
            while (up.X >= 0 && up.Y >= 0 && up.Chessman == Chessman.White)
            {
                if (count == 5)
                    return chessman == Chessman.White ? Winner.White : Winner.Black;
                count++;
                try
                {
                    up = _chessBoard.GetPoint(up.X + stepLong.LeftX, up.Y + stepLong.LeftY);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            return Winner.None;
        }

        private Winner CheckBoth(Point coordinate, string validateMethod)
        {
            var stepLong = ValidateStepLong(validateMethod);
            return Check(coordinate, stepLong, Chessman.White) == Winner.White ? Winner.White :
                Check(coordinate, stepLong, Chessman.Black) == Winner.Black ? Winner.Black : Winner.None;
        }

        [LeftStep(0, -1), RightStep(0, 1)]
        private Winner CheckVertical(Point coordinate)
        {
            return CheckBoth(coordinate, "CheckVertical");
        }

        [LeftStep(-1, 0), RightStep(1, 0)]
        private Winner CheckHorizontal(Point coordinate)
        {
            return CheckBoth(coordinate, "CheckHorizontal");
        }

        [LeftStep(1, -1), RightStep(-1, 1)]
        private Winner CheckLeadingDiagonal(Point coordinate)
        {
            return CheckBoth(coordinate, "CheckLeadingDiagonal");
        }

        [LeftStep(-1, -1), RightStep(1, 1)]
        private Winner CheckDiagonal(Point coordinate)
        {
            return CheckBoth(coordinate, "CheckDiagonal");
        }
    }
}