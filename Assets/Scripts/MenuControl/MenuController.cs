using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    [SerializeField] private GameObject ExitButton;

    [SerializeField] private GameObject LoadingCanvas;

    [SerializeField] private GameObject MenuCanvas;

    [SerializeField] private GameObject OptionsButton;

    [SerializeField] private GameObject PlayButton;

    // Start is called before the first frame update
    private void Start() {
        LoadingCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {
    }


    public void StartGame() {
        MenuCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
        SceneManager.LoadScene("MainGame");
    }

    public void Exit() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    private void ShowLoading() {
    }
}