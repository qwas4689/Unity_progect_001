using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointDiagonalBridge : MonoBehaviour
{
    public GameObject _target;

    private Rigidbody _rigidbody;
    private Vector3 SavePointMoveBridge;

    public bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        SavePointMoveBridge = transform.position - _target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            _rigidbody.velocity = -SavePointMoveBridge * 10f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            isMove = false;
            _rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMove = true;
        }
    }
}
