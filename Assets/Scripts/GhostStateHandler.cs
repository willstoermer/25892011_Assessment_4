using System.Diagnostics;
using UnityEngine;

public class GhostStateHandler : MonoBehaviour
{
    public string state = "Normal";
    public Color mainColour;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = mainColour;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "Normal":
                spriteRenderer.color = mainColour;
                break;
            case "Scared":
                spriteRenderer.color = Color.blue;
                break;
        }
    }
}
