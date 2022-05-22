using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public static bool GameIsFin = false;
    public GameObject Player;
    public GameObject GameEndUI;
    public GameObject MainCanvas;
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float gameTimer;
    public RectTransform timerPos;
    public Timer timer;
    public Vector2 startTimer;
    public Vector2 endTimer;

    private void Start()
    {
        // timerPos = GetComponent<RectTransform>();
        timerPos.transform.position = startTimer;
        //-1600, -930
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pause();
            timer.StopCoroutine("StopWatch");
        }
    }
    void Pause()
    {
        GameEndUI.SetActive(true);
        MainCanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsFin = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerLook.enabled = false;
        playerMovement.enabled = false;
        timerPos.transform.position = endTimer;
        //-890, -584
    }
}