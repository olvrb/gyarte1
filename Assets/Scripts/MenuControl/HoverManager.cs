using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverManager : MonoBehaviour
{
    [SerializeField]
    private Sprite PlayButton;
    [SerializeField]
    private Sprite PlayButtonHover;

    [SerializeField]
    private Sprite OptionsButton;
    [SerializeField]
    private Sprite OptionsButtonHover;

    [SerializeField]
    private Sprite ExitButton;
    [SerializeField]
    private Sprite ExitButtonHover;

    [SerializeField]
    private GameObject PlayObject;
    [SerializeField]
    private GameObject OptionsObject;
    [SerializeField]
    private GameObject ExitObject;

    private Image PlayImage;
    private Image OptionsImage;
    private Image ExitImage;
    // Start is called before the first frame update
    void Start()
    {
        PlayImage = PlayObject.GetComponent<Image>();
        OptionsImage = OptionsObject.GetComponent<Image>();
        ExitImage = ExitObject.GetComponent<Image>();

        PlayImage.sprite = PlayButton;
        OptionsImage.sprite = OptionsButton;
        ExitImage.sprite = ExitButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOnHover() => PlayImage.sprite = PlayButtonHover;

    public void PlayNoHover() => PlayImage.sprite = PlayButton;
    public void OptionsOnHover() => OptionsImage.sprite = OptionsButtonHover;

    public void OptionsNoHover() => OptionsImage.sprite = OptionsButton;
    public void ExitOnHover() => ExitImage.sprite = ExitButtonHover;

    public void ExitNoHover() => ExitImage.sprite = ExitButton;
}
