using UnityEngine;

public class DynamicTopPipeScript : MonoBehaviour
{
    public float MoveSpeed;
    public bool PipeContact = false;
    private float InitialPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
         if (PipeContact == false)
        {
            PipeMoveDown();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PipeMoveUp();
    }
    public void PipeMoveUp()
    {
        PipeContact = true;
        while (transform.position.y < InitialPos)
        {
            transform.position = transform.position + (Vector3.up * MoveSpeed) * Time.deltaTime;
        }
        PipeContact = false;
    }
    public void PipeMoveDown()
    {
        transform.position = transform.position + (Vector3.down * MoveSpeed) * Time.deltaTime;
    }
}
