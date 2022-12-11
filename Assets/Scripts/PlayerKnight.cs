using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnight : MonoBehaviour
{
    public float Speed;
    private Vector3 _distance;
    private bool _isRun = false;
    private Animator _animator => GetComponent<Animator>();
   
    void Update()
    {       
        _distance = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (_distance.x != 0f || _distance.z != 0f)
        {
            _animator.SetBool("isRun", _isRun);
            Movement(_distance);
        }

        if (Input.GetButtonDown("Fire1"))
        {          
            _animator.Play("Attack");
        }       
    }

    public void Movement(Vector3 distance)
    {
        _animator.Play("Run");
        var SpeedTime =  Speed * Time.deltaTime;

        transform.position += distance * SpeedTime;

        if (distance.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(distance), SpeedTime);

    }
}
