using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] bool automatic;
    [SerializeField] int sceneID;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (automatic)
            {
                other.transform.position = new Vector3(0, 1, 0);
                int id = SceneManager.GetActiveScene().buildIndex + 1;
                UIManager.Instance.SaveGame();
                UIManager.Instance.LoadScene(id);
            }
            else
            {
                UIManager.Instance.MainMenu();
            }
        }
    }
}
