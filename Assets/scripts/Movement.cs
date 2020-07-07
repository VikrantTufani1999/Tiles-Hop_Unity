using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject panel;

    private Rigidbody rb;
    //private Touch touch;
    //private float speedModifier;
    [SerializeField] float XpostionRange ;
    [SerializeField] float force;
    [SerializeField] float xfactor;

    private StartGame startGame;
    public Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        //speedModifier = 0.01f;
        rb = GetComponent<Rigidbody>();

        startGame = FindObjectOfType<StartGame>();

        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * force * Time.deltaTime;
        }
    }

    void Update()
    {
        if (startGame.state == StartGame.State.playing)
        {
            BallMovement();
        }
    }

    private void BallMovement()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                //Code for action on mouse moving left
                rb.AddForce(new Vector3(1, 0, 0));
                //rb.AddForce(Vector3.right * xfactor, ForceMode.VelocityChange);
                print("Mouse moved left");
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                //Code for action on mouse moving right
                rb.AddForce(new Vector3(-1, 0, 0));
                //rb.AddForce(-1 * Vector3.right * xfactor, ForceMode.VelocityChange);
                print("Mouse moved right");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            var g = Physics.gravity.magnitude; // get the gravity value
            var vSpeed = Mathf.Sqrt(2 * g * force); // calculate the vertical speed
            rb.velocity = new Vector3(0, vSpeed * 0.5f  , 0); // jump ball
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Invoke("GameEnd", 0.2f);
            startGame.state = StartGame.State.stop;
        }
       
    }

    private void GameEnd()
    {
        SceneManager.LoadScene(1);
    }

    public void play()
    {
        SceneManager.LoadScene("MainScene");
    }
}
