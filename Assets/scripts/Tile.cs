using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Rigidbody rigidbody;
    private StartGame startGame;
    [SerializeField] float speed = 30f;

    private void Awake()
    {
        startGame = FindObjectOfType<StartGame>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (startGame.state == StartGame.State.playing)
            {
            rigidbody.velocity = new Vector3(0, 0, -speed);
        }
    }
}
