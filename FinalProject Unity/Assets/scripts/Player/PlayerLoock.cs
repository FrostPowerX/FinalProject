using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoock : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float xRotation = 0f;

    [SerializeField] float xSensi = 30f;
    [SerializeField] float ySensi = 30f;

    [SerializeField] bool invert;
    [SerializeField] bool onMenu;

    [SerializeField] Controlls controlls;
    [SerializeField] Controlls.OnFootActions onFoot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controlls = new Controlls();
        onFoot = controlls.OnFoot;
        onFoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu) return;
        if (!onMenu && Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Locked;

        LoockProcess();
    }

    private void LoockProcess()
    {
        Vector2 input = onFoot.MouseLook.ReadValue<Vector2>();
        float Xmouse = input.x;
        float mouseY = input.y;

        if (invert) mouseY *= -1;

        xRotation -= (mouseY * Time.deltaTime) * ySensi;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (Xmouse * Time.deltaTime) * xSensi);
    }

    public void SensChange(float X, float Y)
    {
        xSensi = X;
        ySensi = Y;
    }
    public void InvertMode(bool value) => invert = value;
    public void OnMenu(bool value) => onMenu = value;
}
