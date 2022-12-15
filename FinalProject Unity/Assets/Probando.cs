using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Probando : MonoBehaviour
{
    [SerializeField] Controlls controls;
    [SerializeField] Controlls.OnFootActions onFoot;

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controlls();
        onFoot = controls.OnFoot;

        onFoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
