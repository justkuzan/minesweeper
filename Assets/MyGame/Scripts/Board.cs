using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tile tileUnknown;
    public Tile tileEmpty;
    public Tile tileMine;
    public Tile tileExploded;
    public Tile tileFlag;
    public Tile tileNum1;
    public Tile tileNum2;
    public Tile tileNum3;
    public Tile tileNum4;
    public Tile tileNum5;
    public Tile tileNum6;
    public Tile tileNum7;
    public Tile tileNum8;
    public Tilemap tilemap { get; private set; }

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void Draw(Cell[,] state)
    {
        var width = state.GetLength(0);
        var height = state.GetLength(1);

        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
        {
            var cell = state[x, y];
            tilemap.SetTile(cell.position, GetTile(cell));
        }
    }

    private Tile GetTile(Cell cell)
    {
        if (cell.isRevealed) return GetRevealedTile(cell);

        if (cell.isFlagged) return tileFlag;

        return tileUnknown;
    }

    private Tile GetRevealedTile(Cell cell)
    {
        switch (cell.type)
        {
            case Cell.Type.Empty:
                return tileEmpty;
            case Cell.Type.Mine:
                return tileMine;
            case Cell.Type Number:
                return GetNumberTile(cell);
            default: return null;
        }
    }

    private Tile GetNumberTile(Cell cell)
    {
        switch (cell.number)
        {
            case 1:
                return tileNum1;
            case 2:
                return tileNum2;
            case 3:
                return tileNum3;
            case 4:
                return tileNum4;
            case 5:
                return tileNum5;
            case 6:
                return tileNum6;
            case 7:
                return tileNum7;
            case 8:
                return tileNum8;
            default: return null;
        }
    }
}