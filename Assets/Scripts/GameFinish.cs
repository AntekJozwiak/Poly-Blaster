using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public static bool GameIsFin = false;
    public GameObject Player;
    public GameObject GameEndUI;
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float gameTimer;
    public Timer timer;


    private void Update()
    {
        gameTimer = timer.time;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Pause();
        timer.StopCoroutine("StopWatch");
    }
    void Pause()
    {
        GameEndUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsFin = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerLook.enabled = false;
        playerMovement.enabled = false;
        
    }
}