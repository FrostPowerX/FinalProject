using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] PlayerMovement move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground") move.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground") move.SetGrounded(false);
    }
}
