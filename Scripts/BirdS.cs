using UnityEngine;

public class BirdS : MonoBehaviour
{
    public Rigidbody2D Rigid;

    public LogicScript logic;
    public GameObject bg;
    public bool alive =true;
    public static float speed = 5f;

    public AudioClip soundEffect;
    private AudioSource audioSource;
    void Start()
    {
        speed = 5f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y > 7.5f || transform.position.y < -7.5f)
        {
            audioSource.PlayOneShot(soundEffect);
            logic.gameOver();
            alive = false; 
        }
        if ((Input.GetKeyDown(KeyCode.Space)  || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && alive )
        {
            transform.rotation = Quaternion.Euler(0,0,-25);
            Rigid.linearVelocity = Vector2.up * speed;
            
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) && alive)
        {
            transform.rotation = Quaternion.Euler(0, 0, -50);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(soundEffect);
        logic.gameOver();
        alive = false;
    }
}
