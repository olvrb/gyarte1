using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayButton;
    [SerializeField]
    private GameObject OptionsButton;
    [SerializeField]
    private GameObject ExitButton;
    [SerializeField]
    private GameObject MenuCanvas;
    [SerializeField]
    private GameObject LoadingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        LoadingCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        MenuCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    void ShowLoading()
    {

    }
}
