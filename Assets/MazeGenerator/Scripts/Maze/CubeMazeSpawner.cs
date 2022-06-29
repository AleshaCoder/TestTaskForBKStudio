using UnityEngine;

public sealed class CubeMazeSpawner : MazeSpawnerBase
{
    protected override void CheckAndSpawnCell(int row, int column, Transform parent)
    {
        float x = column * CellWidth;
        float z = row * CellHeight;
        if (row < 0 || column < 0 || row >= AmountOfCellsInRow || column >= AmountOfCellsInRow)
            InstantiatePartOfMaze(Roof, new Vector3(x, CellHeight / 2, z), Quaternion.Euler(0, 0, 0), parent);
        base.CheckAndSpawnCell(row, column, parent);
    }

    protected override void Spawn()
    {
        GameObject[] parts = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            GameObject newPart = new GameObject($"part {i}");
            parts[i] = newPart;
            Generate(newPart);
        }
        SetTransformValues(parts);
    }

    private void SetTransformValues(GameObject[] parts)
    {
        parts[0].transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        parts[1].transform.SetPositionAndRotation(new Vector3(0, -CellHeight / 2, -CellHeight / 2), Quaternion.Euler(0, 90, -90));
        parts[2].transform.SetPositionAndRotation(new Vector3(-CellHeight / 2, -CellHeight / 2, 0), Quaternion.Euler(90, -90, 0));
        parts[3].transform.SetPositionAndRotation(new Vector3(0, -CellHeight / 2, CellHeight * AmountOfCellsInRow - CellHeight / 2), Quaternion.Euler(90, 0, 0));
        parts[4].transform.SetPositionAndRotation(new Vector3(0, -CellHeight * AmountOfCellsInRow, CellHeight * AmountOfCellsInRow - CellHeight), Quaternion.Euler(180, 0, 0));
        parts[5].transform.SetPositionAndRotation(new Vector3(CellHeight * AmountOfCellsInRow - CellHeight / 2, -CellHeight / 2, 0), Quaternion.Euler(0, 0, -90));

        transform.position = new Vector3(CellWidth * AmountOfCellsInRow / 2, -CellWidth * AmountOfCellsInRow / 2, CellWidth * AmountOfCellsInRow / 2);

        for (int i = 0; i < 6; i++)
            parts[i].transform.parent = transform;
    }

    private void Start() => Spawn();
}
