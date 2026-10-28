using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private string[,] quarter = new string[,]
    {
        {"x", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "t"},
        {"o", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "i"},
        {"o", "s", "c", "i", "i", "c", "s", "c", "i", "i", "i", "c", "s", "i"},
        {"o", "p", "i", "e", "e", "i", "s", "i", "e", "e", "e", "i", "s", "i"},
        {"o", "s", "c", "i", "i", "c", "s", "c", "i", "i", "i", "c", "s", "c"},
        {"o", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s"},
        {"o", "s", "c", "i", "i", "c", "s", "c", "c", "s", "c", "i", "i", "i"},
        {"o", "s", "c", "i", "i", "c", "s", "i", "i", "s", "c", "i", "i", "c"},
        {"o", "s", "s", "s", "s", "s", "s", "i", "i", "s", "s", "s", "s", "i"},
        {"x", "o", "o", "o", "o", "x", "s", "i", "c", "i", "i", "c", "e", "i"},
        {"e", "e", "e", "e", "e", "o", "s", "i", "c", "i", "i", "c", "e", "c"},
        {"e", "e", "e", "e", "e", "o", "s", "i", "i", "e", "e", "e", "e", "e"},
        {"e", "e", "e", "e", "e", "o", "s", "i", "i", "e", "c", "i", "i", "g"},
        {"o", "o", "o", "o", "o", "x", "s", "c", "c", "e", "i", "e", "e", "e"},
        {"e", "e", "e", "e", "e", "e", "s", "e", "e", "e", "i", "e", "e", "e"}
    };

    private string[,] quarterOrientation = new string[,]
    {
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1"},
        {"1", "0", "0", "0", "0", "3", "0", "0", "0", "0", "0", "3", "0", "1"},
        {"1", "0", "1", "0", "0", "1", "0", "1", "0", "0", "0", "1", "0", "1"},
        {"1", "0", "1", "0", "0", "2", "0", "1", "0", "0", "0", "2", "0", "1"},
        {"1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"1", "0", "0", "0", "0", "3", "0", "0", "3", "0", "0", "0", "0", "0"},
        {"1", "0", "1", "0", "0", "2", "0", "1", "1", "0", "1", "0", "0", "3"},
        {"1", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "1"},
        {"1", "0", "0", "0", "0", "3", "0", "1", "1", "0", "0", "3", "0", "1"},
        {"0", "0", "0", "0", "0", "1", "0", "1", "0", "0", "0", "2", "0", "1"},
        {"0", "0", "0", "0", "0", "1", "0", "1", "1", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "1", "0", "1", "1", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "2", "0", "1", "2", "0", "1", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0"}
    };

    private static string[,,] level;
    private static GameObject[,] levelObjs;
    

    public GameObject prefab;
    public Sprite outsideCorner;
    public Sprite outsideWall;
    public Sprite insideCorner;
    public Sprite insideWall;
    public Sprite standardPellet;
    public Sprite powerPellet;
    public Sprite t;
    public Sprite ghostWall;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        level = new string[ 2, 2 * quarter.GetLength(0) - 1 , 2 * quarter.GetLength(1) ];
        levelObjs = new GameObject[ 2 * quarter.GetLength(0) - 1 , 2 * quarter.GetLength(1) ];
        for (int i = 0; i < level.GetLength(1); i++)
        {
            for (int j = 0; j < level.GetLength(2); j++)
            {
                level[ 0, i, j ] = quarter [ -1 * Mathf.Abs(i - (quarter.GetLength(0) - 1)) + (quarter.GetLength(0) - 1), 
                (int)(-1 * Mathf.Abs(j - (quarter.GetLength(1) - 0.5f)) + (quarter.GetLength(1) - 0.5f)) ];

                level[ 1, i, j ] = quarterOrientation [ -1 * Mathf.Abs(i - (quarterOrientation.GetLength(0) - 1)) + (quarterOrientation.GetLength(0) - 1), 
                (int)(-1 * Mathf.Abs(j - (quarterOrientation.GetLength(1) - 0.5f)) + (quarterOrientation.GetLength(1) - 0.5f)) ];
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < level.GetLength(1); i++)
        {
            for (int j = 0; j < level.GetLength(2); j++)
            {
                Sprite tileSprite = null;
                int xRot = 0;
                int yRot = 0;
                
                switch (level[ 0, i, j ])
                {
                    case "x":
                        tileSprite = outsideCorner;
                        break;
                    case "o":
                        tileSprite = outsideWall;
                        break;
                    case "i":
                        tileSprite = insideWall;
                        break;
                    case "c":
                        tileSprite = insideCorner;
                        break;
                    case "s":
                        tileSprite = standardPellet;
                        break;
                    case "p":
                        tileSprite = powerPellet;
                        break;
                    case "t":
                        tileSprite = t;
                        break;
                    case "g":
                        tileSprite = ghostWall;
                        break;
                }
                
                if (j > 13)
                {
                    yRot = 1;
                }

                if (i < 14)
                {
                    xRot = 1;
                }
                
                levelObjs[ i, j ] = Instantiate(prefab, new Vector3(j - 13, i - 14, 0f), Quaternion.Euler(180f * xRot, 180f * yRot, 90f * int.Parse(level[ 1, i, j ])));
                levelObjs[ i, j ].GetComponent<SpriteRenderer>().sprite = tileSprite;

            }
        }
    }

    public static string getTile(Vector3 position)
    {
        return level[ 0, (int)position.y + 14, (int)position.x + 13 ];
    }

    public static void setTileToEmpty(Vector3 position)
    {
        level[ 0, (int)position.y + 14, (int)position.x + 13 ] = "e";
        levelObjs[ (int)position.y + 14, (int)position.x + 13 ].GetComponent<SpriteRenderer>().enabled = false;
    }
}
