using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] PlayerMovement move;

    private void OnTriggerStay(Collider other)
    {
        if (move.IsGrounded == false && other.gameObject.tag == "Ground") move.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        move.SetGrounded(false);
    }
}
