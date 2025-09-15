using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 0.5f;
    bool goleft = true;
    bool goright = true;
    bool goup = true;
    bool godown = true;
    public bool worried = false;
    public bool right = false;
    public bool down = true;
    public bool up = false;
    public bool walk = false;
    public bool idle = true;
    string lastPressed = "down";
    Animator animator;
    public int playerNumber;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Idle", true);
        animator.SetBool("Down", true);
        if (worried)
        {
            animator.SetBool("Worried", true);
        }
    }

    // Update is called once per frame
    void Move()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.A) && goleft)
        {
            currentPos.x -= speed * Time.deltaTime;
            lastPressed = "left";
        }
        if (Input.GetKey(KeyCode.D) && goright)
        {
            currentPos.x += speed * Time.deltaTime;
            lastPressed = "right";
        }
        if (Input.GetKey(KeyCode.W) && goup)
        {
            currentPos.y += speed * Time.deltaTime;
            lastPressed = "up";
        }
        if (Input.GetKey(KeyCode.S) && godown)
        {
            currentPos.y -= speed * Time.deltaTime;
            lastPressed = "down";
        }
        DetermineAnimation(currentPos);
        transform.position = currentPos;
    }
    void Update()
    {
        if (gameManager.playerActivateNumber == playerNumber)
        {
            Move();
        }
    }

    void DetermineAnimation(Vector3 currentPos)
    {
        if (worried)
        {
            animator.SetBool("Worried", true);
        }
        animator.SetBool("Idle", true);
        //animator.SetBool("Worried", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Walk", false);
        GetComponentInChildren<SpriteRenderer>().flipX = false;
        if (currentPos.x != transform.position.x || currentPos.y != transform.position.y)
        {
            idle = false;
            animator.SetBool("Idle", false);
        }
        else
        {
            idle = true;
            animator.SetBool("Idle", true);
        }
        if (idle)
        {
            
            switch (lastPressed)
            {
                case "down":
                    animator.SetBool("Idle", true);
                    animator.SetBool("Down", true);
                    break;
                case "up":
                    animator.SetBool("Idle", true);
                    animator.SetBool("Up", true);
                    break;
                case "right":
                    animator.SetBool("Idle", true);
                    animator.SetBool("Right", true);
                    break;
                case "left":
                    animator.SetBool("Idle", true);
                    animator.SetBool("Right", true);
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                    break;
            }
        }
        if(!idle)
        {
            animator.SetBool("Idle", false);
            switch (lastPressed)
            {
                case "down":
                    animator.SetBool("Walk", true);
                    animator.SetBool("Down", true);
                    break;
                case "up":
                    animator.SetBool("Walk", true);
                    animator.SetBool("Up", true);
                    break;
                case "right":
                    animator.SetBool("Walk", true);
                    animator.SetBool("Right", true);
                    break;
                case "left":
                    animator.SetBool("Walk", true);
                    animator.SetBool("Right", true);
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("transition")) {
            gameManager.TransitionTrigger(gameObject);
        }
        if (collision.CompareTag("left"))
        {
            goleft = false;
        }
        if (collision.CompareTag("right"))
        {
            goright = false;
        }
        if (collision.CompareTag("top"))
        {
            goup = false;
        }
        if (collision.CompareTag("bottom"))
        {
            godown = false;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("interactable") && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(collision.gameObject.name);
            gameManager.Interact(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goleft = true;

        }
        if (collision.CompareTag("right"))
        {
            goright = true;
        }
        if (collision.CompareTag("top"))
        {
            goup = true;
        }
        if (collision.CompareTag("bottom"))
        {
            godown = true;
        }
    }
}