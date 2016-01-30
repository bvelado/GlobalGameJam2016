using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject titleGameObject;

    public Button playButton, quitButton;

    void Awake()
    {
        DOTween.Init();
    }
    
	void Start () {
        DoInitialTween();
	}

    ////////////////////////////////////////////////////////
    // Button events                                    ////
    ////////////////////////////////////////////////////////

    public void LaunchNewGame()
    {
        // ^
        // |
    }

    public void Exit()
    {
        Application.Quit();
    }

    ////////////////////////////////////////////////////////
    // GFX / Tweening / Animations / SFX                ////
    ////////////////////////////////////////////////////////

    void DoInitialTween()
    {
        // Title shake !!
        titleGameObject.transform.DOShakeScale(3.0f, 1.0f, 6);
        titleGameObject.transform.DOShakeRotation(3.0f, 30.0f, 6);
    }

    public void AnimateOnHoverButton(Button button)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(button.transform.DOScale(1.1f, 0.8f));
        sequence.PrependInterval(0.4f);
        sequence.Insert(0, button.transform.DOShakeScale(0.4f, 0.3f, 2));

        sequence.Play();
    }

    public void AnimateOnHoverExitButton(Button button)
    {
        button.transform.DOScale(1.0f, 0.2f);
    }
}
