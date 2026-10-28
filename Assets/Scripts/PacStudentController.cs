using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private TweenHandler tweenHandler;
    private CollisionHandler collisionHandler;

    private KeyCode lastInput;
    private KeyCode currentInput;

    private Animator animator;
    private float x;
    private float y;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tweenHandler = GetComponent<TweenHandler>();
        collisionHandler = GetComponent<CollisionHandler>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        animator.SetFloat("XChange", transform.position.x - x);
        animator.SetFloat("YChange", transform.position.y - y);
        x = transform.position.x;
        y = transform.position.y;

        collisionHandler.checkItemCollisions(transform.position);

        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }


        if (tweenHandler.activeTween == null)
        {    
            Vector3 targetDirection = new Vector3( 0, 0, 0);

            if (lastInput == KeyCode.W)
            {
                targetDirection = new Vector3( 0, 1, 0);
            }
            else if (lastInput == KeyCode.A)
            {
                targetDirection = new Vector3( -1, 0, 0);
            }
            else if (lastInput == KeyCode.S)
            {
                targetDirection = new Vector3( 0, -1, 0);
            }
            else if (lastInput == KeyCode.D)
            {
                targetDirection = new Vector3( 1, 0, 0);
            }
            
            if (collisionHandler.validDirection(transform.position + targetDirection))
            {
                currentInput = lastInput;
                animator.speed = 1f;
            }
            else
            {
                if (currentInput == KeyCode.W)
                {
                    targetDirection = new Vector3( 0, 1, 0);
                }
                else if (currentInput == KeyCode.A)
                {
                    targetDirection = new Vector3( -1, 0, 0);
                }
                else if (currentInput == KeyCode.S)
                {
                    targetDirection = new Vector3( 0, -1, 0);
                }
                else if (currentInput == KeyCode.D)
                {
                    targetDirection = new Vector3( 1, 0, 0);
                }
                if (!collisionHandler.validDirection(transform.position + targetDirection))
                {
                    targetDirection = new Vector3( 0, 0, 0);
                    animator.speed = 0f;
                }
            }

            tweenHandler.AddTween(transform, transform.position, transform.position + targetDirection, 0.2f);
        }
        
        





        
         
    }
}
