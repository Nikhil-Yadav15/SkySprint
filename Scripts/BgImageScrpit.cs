using System.Drawing;
using UnityEngine;

public class BgImageScrpit : MonoBehaviour
{
    public static float globalSpeed = 2f;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * globalSpeed) * Time.deltaTime;
        if (transform.position.x < -25) { Destroy(gameObject); }
     

    }
}
