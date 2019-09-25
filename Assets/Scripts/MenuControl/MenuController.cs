using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayButton;
    [SerializeField]
    private GameObject OptionsButton;
    [SerializeField]
    private GameObject ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnHover()
    {

    }
}
