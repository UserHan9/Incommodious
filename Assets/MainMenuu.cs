using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuu : MonoBehaviour
{
    public void mainmenu(){


    SceneManager.LoadScene("CutScene");
    }

        public void exit(){

            Application.Quit();
    
    }

   
}
