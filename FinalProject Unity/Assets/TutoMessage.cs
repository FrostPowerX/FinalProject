using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoMessage : MonoBehaviour
{
    [SerializeField] string message;
    [SerializeField] float time;

    [SerializeField] Color color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.Message(message, time, color);
            Destroy(gameObject);
        }
    }
}
