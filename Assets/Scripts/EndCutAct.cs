using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutAct : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject player;
    public GameObject main;
    public GameObject endgame;

    public void cutstart()
    {
        Time.timeScale = 1f;
        cutscene.SetActive(true);    
        Destroy(player);
        main.SetActive(false);
        endgame.SetActive(false);
    }

}
