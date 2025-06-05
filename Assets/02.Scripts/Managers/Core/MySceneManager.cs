using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager 
{
   public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }  


    public void LoadScene(Define.ESCENE type, Transform parents = null)
    {
        switch(CurrentScene.SceneType)      
        {
            case Define.ESCENE.TITLESCENE:
                Managers.Clear();
                SceneManager.LoadScene(GetSceneName(type));

                break;
            case Define.ESCENE.LOBBYSCENE:
                Managers.Clear();
                SceneManager.LoadScene(GetSceneName(type));
                break;
            case Define.ESCENE.GAMESCENE:
                Managers.Clear();
                SceneManager.LoadScene(GetSceneName(type));
                break;
       
        }
    }



    string GetSceneName(Define.ESCENE type)
    {
        string name = System.Enum.GetName(typeof(Define.ESCENE), type);
        return name;
    }
    public void Clear()
    {
        CurrentScene.Clear();
    }
}
