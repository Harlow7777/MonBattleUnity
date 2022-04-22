using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startNewGame() 
    {
        SceneManager.LoadScene(sceneName:"Game");
    }
}
