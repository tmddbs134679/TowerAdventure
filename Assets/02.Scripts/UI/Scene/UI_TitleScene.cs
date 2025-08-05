using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_TitleScene : UI_Scene
{

    enum GameObjects
    {
        Slider,
    }
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

        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));


        GetObject((int)GameObjects.Slider).GetComponent<Slider>().value = 0;
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(() =>
        {
            //일단 바로 GamesScene으로
            if (isPreload)
                Managers.Scene.LoadScene(Define.ESCENE.GAMESCENE, transform);
        });

        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);
        return true;
    }

    private void Awake()
    {
        Init();
    }


    private void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            GetObject((int)GameObjects.Slider).GetComponent<Slider>().value = (float)count / totalCount;
            if (count == totalCount)
            {
                isPreload = true;
                    GetButton((int)Buttons.StartButton).gameObject.SetActive(true);
                    Managers.Data.Init();
                    StartButtonAnimation();
            }
        });
    }

    void StartButtonAnimation()
    {
        GetText((int)Texts.StartText).DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic).Play();
    }
}
