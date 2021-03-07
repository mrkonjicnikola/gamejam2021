using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public bool playerFinish;
    public bool shadowFinish;

    void Start()
    {
        playerFinish = false;
        shadowFinish = false;
    }

    void Update()
    {
        if(playerFinish && shadowFinish) {
            print("simultanious finish");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //change level
        }
        
        //if(playerFinish) print("player finished");
        //if(shadowFinish) print("shadow finished");
    }

    public void toggleShadowFinishBool() {
        shadowFinish = !shadowFinish;
        if (shadowFinish) Invoke("toggleShadowFinishBool", 1.2f);
    }

    public void togglePlayerFinishBool() {
        playerFinish = !playerFinish;
        if (playerFinish) Invoke("togglePlayerFinishBool", 1.2f);
    }

}
