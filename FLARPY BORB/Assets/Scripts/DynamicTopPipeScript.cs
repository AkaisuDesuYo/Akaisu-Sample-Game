using Unity.VisualScripting;
using UnityEngine;

public class DynamicTopPipeScript : MonoBehaviour
{
    public float MoveSpeed;
    private bool PipeContact = false;
    private bool ReturnToInitial = false;
    private float InitialPos;


    void Start()
    {
        InitialPos = transform.position.y;
    }


    void FixedUpdate()
    {
        if (PipeContact == false && !ReturnToInitial)
        {
            PipeMoveDown();
        }
        if (ReturnToInitial)
        {
            PipeMoveUp();
            if (transform.position.y >= InitialPos)
            {
                transform.position = new Vector3(transform.position.x, InitialPos, transform.position.z);
                ReturnToInitial = false;
                PipeContact = true;
            }
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PipeComponent")
        {
            PipeContact = true;
            ReturnToInitial = true;
        }
    }
    public void PipeMoveUp()
    {
        transform.position = transform.position + (transform.up * MoveSpeed) * Time.deltaTime;
    }
    public void PipeMoveDown()
    {
        transform.position = transform.position - (transform.up * MoveSpeed) * Time.deltaTime;
    }
}