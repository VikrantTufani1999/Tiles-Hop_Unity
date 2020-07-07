using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Material[] material;

    private Movement ball;

    Renderer render;



    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Movement>();
        render = GetComponent<Renderer>();
        render.enabled = true;
        int i = Random.Range(0, 3);
        render.sharedMaterial = material[i];

        //render.sharedMaterial = material[0];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("hit");
        }
    }

}
