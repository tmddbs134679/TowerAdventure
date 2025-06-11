using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ObjectManager
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();

    public T Spawn<T>(Vector3 position, int templateID = 0, string prefabName = "") where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            GameObject go = Managers.Resource.Instantiate(Managers.Data.CreatureDic[templateID].PrefabLabel);
            go.transform.position = position;
            PlayerController pc = go.GetOrAddComponent<PlayerController>();
            pc.SetInfo(templateID);
            Player = pc;
            // Managers.Game.Player = pc;
            //PlayerSelector.Inst.selectedPlayer = pc;
            return pc as T;
        }
        else if(type == typeof(MonsterController))
        {
            Data.CreatureData cd = Managers.Data.CreatureDic[templateID];
            GameObject go = Managers.Resource.Instantiate($"{cd.PrefabLabel}",pooling: true);
            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            go.transform.position = position;
            mc.SetInfo(templateID);
            mc.name = cd.PrefabLabel;
            Monsters.Add(mc);

            return mc as T;
        }
        else if (type == typeof(ProjectileController))
        {
            GameObject go = Managers.Resource.Instantiate(prefabName, pooling: true);
            ProjectileController pc = go.GetOrAddComponent<ProjectileController>();
            go.transform.position = position;
            Projectiles.Add(pc);

            return pc as T;
        }


        return null;
    }

    public void Despawn<T>(T obj) where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(MonsterController))
        {
            Monsters.Remove(obj as MonsterController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(ProjectileController))
        {
            Projectiles.Remove(obj as ProjectileController);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }



    public void Clear()
    {
       
    }


}