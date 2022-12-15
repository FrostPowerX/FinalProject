using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(0, 1, 0);
            int id = 1 + SceneManager.GetActiveScene().buildIndex;
            UIManager.Instance.SaveGame();
            UIManager.Instance.LoadScene(id);
        }
    }
}
