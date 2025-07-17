using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public GameObject topPipe;
    public GameObject bottomPipe;
    public float spawnRate;
    public float spawnTimer = 0.01F;
    private float timer = 0;
    public float heightoffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
            spawnRate -= spawnTimer;
        }
                  
            
    }
    void spawnPipe ()
    {
        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;

        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        Debug.Log("Pipe Spawned");
    }
}
