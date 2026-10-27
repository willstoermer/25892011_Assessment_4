using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool validVector(Vector3 position)
    {
        if (LevelManager.getTile(position) != "s" && LevelManager.getTile(position) != "p" && LevelManager.getTile(position) != "e")
        {
            return false;
        }
        return true;
    }
}
