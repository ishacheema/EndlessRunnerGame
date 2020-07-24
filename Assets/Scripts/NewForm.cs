using UnityEngine;
using System.Collections;

public class NewForm : MonoBehaviour {

    public string LoadScene;

    public void NextSlide()
    {
      
            Application.LoadLevel(LoadScene);
               
      }
    }
