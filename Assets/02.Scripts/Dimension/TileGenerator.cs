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
    int height = 3;
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
        height = EditorGUILayout.IntField("Heights", height);
        spacing = EditorGUILayout.FloatField("Spacing", spacing);

        if (GUILayout.Button("Generate"))
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

        for (int y = 0; y < height; y++) // Y축 쌓기
        {
            for (int z = 0; z < rows; z++) // 세로
            {
                for (int x = 0; x < cols; x++) // 가로
                {
                    Vector3 pos = new Vector3(x * spacing, y * spacing, z * spacing);

                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(tilePrefab, SceneManager.GetActiveScene());
                    instance.transform.position = pos;
                    instance.transform.SetParent(parent.transform);
                }
            }
        }
    }
}
