using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public PlayerKnight PlayerKnight;
    public float Force;
    private bool _boolClipName;

    
    private void OnTriggerEnter(Collider other)
    {
        _boolClipName = PlayerKnight.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack");


        if (other.CompareTag("BettonCube") && _boolClipName)
        {
            other.transform.SetParent(null);
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().useGravity = true;
            var offset = other.transform.position - transform.position;
            var distance = offset.normalized;
            other.GetComponent<Rigidbody>().AddForce(distance * Force, ForceMode.Impulse);
        }

       
    }
}
