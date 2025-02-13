using UnityEngine;

public class BGScrpit : MonoBehaviour
{
    public GameObject bg;
    public float timer = 0;
    public static float rate = 9.6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BgImageScrpit.globalSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < rate) { timer += Time.deltaTime; }
        else
        {
            Instantiate(bg, new Vector3(transform.position.x, 0, 5), transform.rotation);
            timer = 0;
        }  }
}
