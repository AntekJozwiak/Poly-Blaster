using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject firstSlide;
    [SerializeField] GameObject secondSlide;
    public void StartPressed()
    {
        anim.SetTrigger("CamSlide");
        firstSlide.SetActive(false);
        secondSlide.SetActive(true);
    }

    public void BackPressed()
    {
        anim.SetTrigger("BackCamSlide");
        firstSlide.SetActive(true);
        secondSlide.SetActive(false);
    }
    public void Generators()
    {
        SceneManager.LoadScene("Generators");
    }

    public void Kamino()
    {
        SceneManager.LoadScene("Kamino");
    }

    public void GeneratorsDis()
    {
        SceneManager.LoadScene("GeneratorsDis");
    }

    public void KaminoDis()
    {
        SceneManager.LoadScene("KaminoDis");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}