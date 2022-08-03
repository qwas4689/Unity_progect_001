using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollChanger : MonoBehaviour
{
    public GameObject _player;
    public GameObject _ragdollPlayer;
    public GameObject _ragdollPrefab;

    public bool _isRagdoll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeRagdoll()
    {
        changeRagdollPosition();
        changeRagdollMovement(_player.transform, _ragdollPlayer.transform);

        Instantiate(_ragdollPrefab);

        // _ragdollPrefab.SetActive(false);
        _player.SetActive(false);

        // _ragdollPlayer.SetActive(true);

        _isRagdoll = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            changeRagdoll();
            GameManager.Instance.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            changeRagdoll();
        }
    }

    private void changeRagdollPosition()
    {
        _ragdollPlayer.transform.position = _player.transform.position;
    }

    private void changeRagdollMovement(Transform _player, Transform _ragdoll)
    {
        for (int i = 0; i < _player.childCount; i++)
        {
            if (_player.childCount != 0)
            {
                changeRagdollMovement(_player.GetChild(i), _ragdoll.GetChild(i));
            }

            _ragdoll.GetChild(i).localPosition = _player.GetChild(i).localPosition;
            _ragdoll.GetChild(i).localRotation = _player.GetChild(i).localRotation;
        }

    }





}
