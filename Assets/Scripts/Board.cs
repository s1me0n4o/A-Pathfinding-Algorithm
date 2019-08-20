using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int rows, cols;
    [SerializeField] private BoardTile[,] board;
    [SerializeField] private BoardTile[] tilesPrefabs;

    private Vector3 startPos;

    float hexWidth = 1f;
    float hexHeight = 1f;

    public void Generate()
    {
        CalcStartPos();

        board = new BoardTile[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                CreateTile(r, c);
            }
        }
    }

    private void CreateTile(int r, int c)
    {
        int randTile = Random.Range(0, 5);
        var newTilePref = tilesPrefabs[randTile];

        BoardTile newTile = Instantiate(newTilePref) as BoardTile;
        board[r, c] = newTile;
        Vector2 tilePos = new Vector2(r, c);
        newTile.name = "Tile: " + r + "," + c;
        newTile.transform.parent = transform;
        newTile.transform.localPosition = CalcPos(tilePos);
    }

    private Vector3 CalcPos(Vector3 pos)
    {
        float offset = 0;
        if (pos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + pos.x * hexWidth + offset;
        float z = startPos.z - pos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    private void CalcStartPos()
    {
        float offset = 0;
        if (cols / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (rows / 2) - offset;
        float z = hexHeight * 0.75f * (cols / 2);

        startPos = new Vector3(x, 0, z);
    }
}
