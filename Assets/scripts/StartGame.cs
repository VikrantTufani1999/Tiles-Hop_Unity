using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] Rigidbody ball;
    [SerializeField] float upSpeed = 5f;
    public enum State { begin, playing, stop };
    public State state = State.begin;

    [Header("Tile")]
    [SerializeField] Tile tile;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] int Xrange = 3;
    [SerializeField] Transform newParent;

    // Start is called before the first frame update
    void Start()
    {
        ball.isKinematic = true;

       
        
    }

    IEnumerator TileSpawner()
    {
        while (true)
        {
            var Xposition = Random.Range(-Xrange, Xrange);
            var prefab = Instantiate(tile, new Vector3(Xposition, 3, 40), Quaternion.identity);
            prefab.transform.parent = newParent;
            print("I am in loop");
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.begin)
        {
            if (Input.GetMouseButtonDown(0))
            {
                state = State.playing;
                ball.isKinematic = false;
                ball.velocity = new Vector3(0, upSpeed, 0);

                StartCoroutine(TileSpawner());
            }
        }
    }
}
