using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyTile", 10f);   
    }

    private void DestroyTile()  // call by string refrence
    {
        Destroy(gameObject);
    }
}
