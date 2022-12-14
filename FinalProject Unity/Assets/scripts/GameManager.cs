using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] GameObject player;

    [SerializeField] int currentScore;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
