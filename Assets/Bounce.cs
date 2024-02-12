using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _collider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_collider)
        {
            _rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
        
        if (_collider)
        {
            _rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
      
    }
}
