using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_TitleScene : UI_Scene
{
    enum Buttons
    {
        StartButton
    }

    enum Texts
    {
        StartText
    }

    bool isPreload = false;
    public override bool Init()
    {
         if(base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(() =>
        {
            if (isPreload)
                SceneManager.LoadScene(1);
        });

        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);
        return true;
    }

    private void Awake()
    {
        Init();
    }

    void Start()
    {

        isPreload = true;
        GetButton((int)Buttons.StartButton).gameObject.SetActive(true);

        StartButtonAnimation();
    }


    void StartButtonAnimation()
    {
        GetText((int)Texts.StartText).DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic).Play();
    }
}
