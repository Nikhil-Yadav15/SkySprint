using UnityEngine;

public class IndividualPipe : MonoBehaviour
{
    public static float globalSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * globalSpeed) * Time.deltaTime;
        if (transform.position.x < -14) { Destroy(gameObject); }
    }
}
