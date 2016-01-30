using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuController : MonoBehaviour {

    public GameObject titleGameObject;

    void Awake()
    {
        DOTween.Init();
    }

	// Use this for initialization
	void Start () {
        titleGameObject.transform.DOShakeScale(3.0f, 1.0f, 6);
        titleGameObject.transform.DOShakeRotation(3.0f, 30.0f, 6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
