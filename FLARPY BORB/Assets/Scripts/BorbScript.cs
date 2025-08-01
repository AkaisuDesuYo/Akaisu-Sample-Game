using UnityEngine;

public class BorbScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript Logic;
    private float DeadZoneTop = 4.83F;
    private float DeadZoneBot = -4.50F;
    public bool BirdIsAlive = true;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Logic.gameIsDead == false)
        {
            Logic.freezeFrame(0);
        }
        else if (Logic.gameIsDead == true)
        {
            Logic.freezeFrame(1);
            if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
            {
                myRigidbody.linearVelocity = Vector2.up * flapStrength;
            }
            if (transform.position.y > DeadZoneTop || transform.position.y < DeadZoneBot)
            {
                Logic.gameOver();
                BirdIsAlive = false;
            }           
            if (BirdIsAlive == false)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.gameOver();
        BirdIsAlive = false;
    }
}
