using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.SceneManagement;

public class TileGenerator : EditorWindow
{
    GameObject tilePrefab;
    int rows = 5;
    int cols = 5;
    float spacing = 1f;

    [MenuItem("Tools/Tile Grid Generator")]
    static void Init()
    {
        GetWindow<TileGenerator>("Tile Grid Generator");
    }

    private void OnGUI()
    {
        tilePrefab = (GameObject)EditorGUILayout.ObjectField("Tile Prefab", tilePrefab, typeof(GameObject), false);
        rows = EditorGUILayout.IntField("Rows", rows);
        cols = EditorGUILayout.IntField("Cols", cols);
        spacing = EditorGUILayout.FloatField("Spacing", spacing);

        if (GUILayout.Button("Generatge"))
        {
            GenerateGrid();
        }


    }

    private void GenerateGrid()
    {
       if(tilePrefab == null)
       {
           Debug.Log("타일 할당 x");
           return;
       }

        GameObject parent = new GameObject("TileGrid");

        for(int y = 0; y< rows; y++)
        {
            for(int x = 0; x< cols; x++)
            {
                Vector3 pos = new Vector3(x * spacing, 0, y * spacing);

                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(tilePrefab, SceneManager.GetActiveScene());
                instance.transform.position = pos;
                instance.transform.SetParent(parent.transform);
            }
        }
    }
}
