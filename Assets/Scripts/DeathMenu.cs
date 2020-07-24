using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {

    public Text finalScoreText;
    public ScoreManager theScoreManager;

    public string mainMenuLevel;

   
    public void Start()
    {
       
        FindObjectOfType<ScoreManager>().DeathScore();
        
    }

    
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }


}
