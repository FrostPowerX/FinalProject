using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] string nameSound;
    [SerializeField] AudioSource _as;

    [SerializeField] bool active;

    // Start is called before the first frame update
    void Start()
    {
        _as.Play();
    }
}
