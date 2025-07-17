using UnityEngine;

public class DynamicTopPipeScript : MonoBehaviour
{
    public float MoveSpeed;
    public bool PipeContact = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PipeContact == true)
        {
            PipeMoveUp();
        }
        else if (PipeContact == false)
        {
            PipeMoveDown();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PipeContact = true;
    }
    public void PipeMoveUp()
    {
        transform.position = transform.position + (Vector3.up * MoveSpeed) * Time.deltaTime;
    }
    public void PipeMoveDown()
    {
        transform.position = transform.position + (Vector3.down * MoveSpeed) * Time.deltaTime;
    }
}
