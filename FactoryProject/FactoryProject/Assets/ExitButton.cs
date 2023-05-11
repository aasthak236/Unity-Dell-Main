using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
//#if UNITY_STANDALONE_WIN
   // public Button exitButton;

    void Start()
    {
       // exitButton.onClick.AddListener(ExitGame);
    }

   public  void ExitGame()
    {
        // Display a confirmation dialog box
      // bool confirmExit = MessageBox.Show("Are you sure you want to exit the game?", "Exit Game", MessageBoxButtons.YesNo);

        // If the user confirms the exit, quit the application
        //if (confirmExit == true)
        //{
            Application.Quit();
       // }
    }
//#endif
}