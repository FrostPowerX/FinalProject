using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] GameObject prefabPlayer;
    [SerializeField] GameObject player;

    [SerializeField] int currentScore;

    public GameObject Player { get { return player; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Vector3 position = new Vector3(0, 1, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        player = Instantiate(prefabPlayer, position, rotation);

        EventManager.OnPlayerDeath += PlayerDeath;
    }

    private void Start()
    {
        
    }

    private void PlayerDeath()
    {
        UIManager.Instance.SetPanelLoseActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }

    public Vector3 GetPlayerHeadPos()
    {
        return player.transform.Find("PlayerCam").transform.position;
    }
}
