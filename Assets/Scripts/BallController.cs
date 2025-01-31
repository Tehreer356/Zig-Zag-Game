using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject particle;

    private Rigidbody rb;
    private bool started;
    private bool gameOver;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
       started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.Instance.StartGame();
                
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) 
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25, 0);
            Camera.main.GetComponent<FollowBall>().gameOver = true;
            GameManager.Instance.GameOver();
        }
        Debug.DrawRay(transform.position,Vector3.down,Color.red);
        if (Input.GetMouseButtonDown(0)&& !gameOver) 
        {
            SwitchDirection();
        }
    }
    private void SwitchDirection() 
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if (rb.velocity.z > 0) 
        {
            rb.velocity= new Vector3(speed, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond") 
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(part,1f);

            
        }
    }
}
