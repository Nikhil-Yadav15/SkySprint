using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectedPipe : MonoBehaviour
{
    public GameObject pipe;
    public LogicScript logic;
    public float baseSpawnRate = 4f;    // Initial spawn interval (seconds)
    public float minSpawnRate = 1f;   // Fastest possible spawn interval
    public float rateDecreasePerScore = 0.1f; // How much faster pipes spawn per score point
    public float height = 4;
    public static float currentSpawnRate = 4f;
    public static bool levelup = false;

    private float timer = 0;
    private LogicScript scoreManager;

    void Start()
    {
        levelup = false;
        currentSpawnRate = 4f;
        scoreManager = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(transform.position.y - height, transform.position.y + height), 0), transform.rotation);
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
    }

    void Update()
    {
        float low = transform.position.y - height;
        float high = transform.position.y + height;

        // Timer logic
        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
            timer = 0;
        }
    }
}