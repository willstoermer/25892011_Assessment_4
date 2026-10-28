using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private TweenHandler tweenHandler;
    private CollisionHandler collisionHandler;

    private Vector3 newVector;
    private Vector3 currentVector = new Vector3( 0, 0, 0 );
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tweenHandler = GetComponent<TweenHandler>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        collisionHandler.checkItemCollisions(transform.position);


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            newVector = new Vector3( Input.GetAxisRaw("Horizontal"), 0, 0 );
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            newVector = new Vector3( 0, Input.GetAxisRaw("Vertical"), 0 );
        }
      
        if (!collisionHandler.validVector(transform.position + currentVector))
        {
            currentVector = new Vector3( 0, 0, 0 );
        }
        
        if (collisionHandler.validVector(transform.position + newVector))
        {
            currentVector = newVector;
        }
        
        tweenHandler.AddTween(transform, transform.position, transform.position + currentVector, 0.25f);
    }
}
