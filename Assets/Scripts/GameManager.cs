using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI vidasText;
    //Singleton
    //
    public static GameManager instance 
    { 
        get; private set; 
    }

    public int gunAmmo = 10;
    public int vidas = 10;
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
     //   ammoText.text=gunAmmo.ToString();
        vidasText.text=vidas.ToString();
    }

    public void LoseHealth(int heltToReduce)
    {
        vidas-=heltToReduce;
        if (vidas <= 0)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex);
        }
    }
}
