using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    //加载场景
    public void OnStartGame() {
        Application.LoadLevel("MapWithCamera");
    }

    public void OnQuitGame() {
        Application.Quit();
    }
}
