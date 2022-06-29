using UnityEngine;
using System;

public class RecursiveMazeGenerator
{
    public int RowCount { get; }
    public int ColumnCount { get; }

    public int GoalCount;
    private MazeCell[,] _maze;

    public RecursiveMazeGenerator(int rows, int columns)
    {
        RowCount = Mathf.Clamp(rows, 1, Mathf.Abs(rows));
        ColumnCount = Mathf.Clamp(columns, 1, Mathf.Abs(columns));

        _maze = new MazeCell[rows, columns];

        for (int row = 0; row < rows; row++)
            for (int column = 0; column < columns; column++)
                _maze[row, column] = new MazeCell();
    }

    public void GenerateMaze() => VisitCell(0, 0, Direction.Start);

    private void VisitCell(int row, int column, Direction moveMade)
    {
        Direction[] movesAvailable = new Direction[4];
        int movesAvailableCount = 0;

        do
        {
            movesAvailableCount = 0;

            TryMoveRight(row, column, moveMade, movesAvailable, ref movesAvailableCount);
            TryMoveForward(row, column, moveMade, movesAvailable, ref movesAvailableCount);
            TryMoveLeft(row, column, moveMade, movesAvailable, ref movesAvailableCount);
            TryMoveDown(row, column, moveMade, movesAvailable, ref movesAvailableCount);

            DeleteWallsNearEdges(row, column);

            if (movesAvailableCount == 0 && !GetMazeCell(row, column).IsVisited && GoalCount > 0)
            {
                GetMazeCell(row, column).IsGoal = true;
                GoalCount--;
            }

            GetMazeCell(row, column).IsVisited = true;

            if (movesAvailableCount > 0)
            {
                switch (movesAvailable[UnityEngine.Random.Range(0, movesAvailableCount)])
                {
                    case Direction.Start:
                        break;
                    case Direction.Right:
                        VisitCell(row, column + 1, Direction.Right);
                        break;
                    case Direction.Front:
                        VisitCell(row + 1, column, Direction.Front);
                        break;
                    case Direction.Left:
                        VisitCell(row, column - 1, Direction.Left);
                        break;
                    case Direction.Back:
                        VisitCell(row - 1, column, Direction.Back);
                        break;
                }
            }
        } while (movesAvailableCount > 0);
    }

    private void TryMoveRight(int row, int column, Direction moveMade, Direction[] movesAvailable, ref int movesAvailableCount)
    {
        if (column + 1 < ColumnCount && !GetMazeCell(row, column + 1).IsVisited)
        {
            movesAvailable[movesAvailableCount] = Direction.Right;
            movesAvailableCount++;
        }
        else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Left)
        {
            GetMazeCell(row, column).WallRight = true;
        }
    }

    private void TryMoveForward(int row, int column, Direction moveMade, Direction[] movesAvailable, ref int movesAvailableCount)
    {
        if (row + 1 < RowCount && !GetMazeCell(row + 1, column).IsVisited)
        {
            movesAvailable[movesAvailableCount] = Direction.Front;
            movesAvailableCount++;
        }
        else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Back)
        {
            GetMazeCell(row, column).WallFront = true;
        }
    }

    private void TryMoveLeft(int row, int column, Direction moveMade, Direction[] movesAvailable, ref int movesAvailableCount)
    {
        if (column > 0 && column - 1 >= 0 && !GetMazeCell(row, column - 1).IsVisited)
        {
            movesAvailable[movesAvailableCount] = Direction.Left;
            movesAvailableCount++;
        }
        else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Right)
        {
            GetMazeCell(row, column).WallLeft = true;
        }
    }

    private void TryMoveDown(int row, int column, Direction moveMade, Direction[] movesAvailable, ref int movesAvailableCount)
    {
        if (row > 0 && row - 1 >= 0 && !GetMazeCell(row - 1, column).IsVisited)
        {
            movesAvailable[movesAvailableCount] = Direction.Back;
            movesAvailableCount++;
        }
        else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Front)
        {
            GetMazeCell(row, column).WallBack = true;
        }
    }

    private void DeleteWallsNearEdges(int row, int column)
    {
        if (row == 0)
            GetMazeCell(row, column).WallBack = false;
        if (row == RowCount-1)
            GetMazeCell(row, column).WallFront = false;
        if (column == 0)
            GetMazeCell(row, column).WallLeft = false;
        if (column == ColumnCount-1)
            GetMazeCell(row, column).WallRight = false;
    }

    public MazeCell GetMazeCell(int row, int column)
    {
        bool cellExists = row >= 0 && column >= 0 && row < RowCount && column < ColumnCount;

        if (cellExists)
            return _maze[row, column];
        else
            throw new ArgumentOutOfRangeException($"row {row}, column {column}");
    }
}
