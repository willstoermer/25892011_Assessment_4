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

    private static string[,] level;
    

    public GameObject wall;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        level = new string[ 2 * quarter.GetLength(0) - 1 , 2 * quarter.GetLength(1)];
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                level[ i, j ] = quarter [ -1 * Mathf.Abs(i - (quarter.GetLength(0) - 1)) + (quarter.GetLength(0) - 1), 
                (int)(-1 * Mathf.Abs(j - (quarter.GetLength(1) - 0.5f)) + (quarter.GetLength(1) - 0.5f)) ];
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (level[ i, j ] != "s" && level[ i, j ] != "p" && level[ i, j ] != "e")
                {
                    GameObject wallInstance = Instantiate(wall, new Vector3(j - 13, i - 14, 0f), Quaternion.identity);
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string getTile(Vector3 position)
    {
        return level[ -(int)position.y + 14, (int)position.x + 13 ];
    }
}
