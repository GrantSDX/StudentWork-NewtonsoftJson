using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetonCubeDestroy : MonoBehaviour
{
    public GameObject Betton;

    private void Update()
    {
        if (transform.position.y < -0.1f)
            Destroy(Betton);
    }

}
