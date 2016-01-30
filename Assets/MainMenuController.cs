using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject titleGameObject;

    public Button playButton, quitButton;

    public Sequence buttonSequence;

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
        SceneManager.LoadScene(1);
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
        button.transform.DOScale(1.1f, 0.4f);
    }

    public void AnimateOnHoverExitButton(Button button)
    {
        button.transform.DOScale(1.0f, 0.4f);
    }
}
