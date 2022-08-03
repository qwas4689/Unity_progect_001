using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointBridge : MonoBehaviour
{
    public GameObject _target;
    public GameObject _diagonalTarget;

    private Rigidbody _rigidbody;
    private Vector3 SavePointMoveBridge;
    private Vector3 SavePointDiagonalBridge;

    private bool XMoving;
    private bool YMoving;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        SavePointMoveBridge = _target.transform.position - transform.position;

        SavePointMoveBridge.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (XMoving)
        {
            Debug.Log("X작동");
            _rigidbody.velocity = SavePointMoveBridge * 10f * Time.deltaTime;
        }

        if (YMoving)
        {
            Debug.Log("Y작동");
            _rigidbody.velocity = SavePointDiagonalBridge * 10f * Time.deltaTime;
        }

        Debug.DrawRay(transform.position,SavePointDiagonalBridge, Color.red); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            XMoving = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            Debug.Log("트리거 작동");
            XMoving = false;
            _rigidbody.velocity = new Vector3(0f, 0f, 0f);

            YMoving = true;
            SavePointDiagonalBridge =  _diagonalTarget.transform.position - transform.position;
        }

        if (other.tag == "EndPoint")
        {
            _rigidbody.velocity = new Vector3(0f, 0f, 0f);
            YMoving = false;
        }
    }
}
