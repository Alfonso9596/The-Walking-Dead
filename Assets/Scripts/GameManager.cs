using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    [SerializeField]
    private GameObject player;

    public GameObject Player
    {
        get { return player; }
    }

    private bool isAlertActive = false;

    public bool IsAlertActive
    {
        get { return isAlertActive; }
        set { isAlertActive = value; }
    }

    private bool isGamePaused = false;

    public bool IsGamePaused
    {
        get { return isGamePaused; }
        set { isGamePaused = value; }
    }
    private bool isSafeZoneActive = false;

    public bool IsSafeZoneActive
    {
        get { return isSafeZoneActive; }
        set { isSafeZoneActive = value; }
    }

    private bool isPlayerAlive = true;

    public bool IsPlayerAlive
    {
        get { return isPlayerAlive; }
        set { isPlayerAlive = value; }
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
        isAlertActive = false;
    }

    private void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
