using UnityEngine;

public abstract class MazeSpawnerBase : MonoBehaviour
{
    public GameObject Roof = null;
    public GameObject Floor = null;
    public GameObject Wall = null;
    public GameObject Final = null;
    public GameObject GoalPrefab = null;

    public int AmountOfCellsInRow = 5;
    public int GoalCount = 1;
    public float CellWidth = 4;
    public float CellHeight = 4;

    protected RecursiveMazeGenerator _mazeGenerator = null;

    protected void Generate(GameObject part)
    {
        _mazeGenerator = new RecursiveMazeGenerator(AmountOfCellsInRow, AmountOfCellsInRow);
        _mazeGenerator.GoalCount = GoalCount;
        _mazeGenerator.GenerateMaze();

        for (int row = -1; row < AmountOfCellsInRow + 1; row++)
            for (int column = -1; column < AmountOfCellsInRow + 1; column++)
                CheckAndSpawnCell(row, column, part.transform);
    }

    protected virtual void CheckAndSpawnCell(int row, int column, Transform parent)
    {
        float x = column * CellWidth;
        float z = row * CellHeight;
        InstantiatePartOfMaze(Roof, new Vector3(x, CellHeight / 2, z), Quaternion.Euler(0, 0, 0), parent);
        if (row < 0 || column < 0 || row >= AmountOfCellsInRow || column >= AmountOfCellsInRow)
            return;
        MazeCell cell = _mazeGenerator.GetMazeCell(row, column);

        if (GoalPrefab != null)
        {
            if (!cell.IsGoal)
                InstantiatePartOfMaze(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0), parent);
            else if (cell.IsGoal)
                InstantiatePartOfMaze(Final, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0), parent);

            if (cell.WallRight)
                InstantiatePartOfMaze(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0), parent);

            if (cell.WallFront)
                InstantiatePartOfMaze(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0), parent);

            if (cell.WallLeft)
                InstantiatePartOfMaze(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0), parent);

            if (cell.WallBack)
                InstantiatePartOfMaze(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0), parent);
        }
    }

    protected void InstantiatePartOfMaze(GameObject gameObject, Vector3 position, Quaternion quaternion, Transform parent)
    {
        GameObject tmp;
        tmp = Instantiate(gameObject, position, quaternion);
        tmp.transform.parent = parent;
    }

    protected abstract void Spawn();
}