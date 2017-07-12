using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using UnityEditorInternal;
[CustomEditor(typeof(EnemyController))]
public class EnemyControllerInpector : Editor {
    Vector2 scrollPosition;
    //private ReorderableList list;//Note, figure out reordable list at a later date, would be handy here

    private void changeArraySize(int newSize)
    {
        EnemyController boop = (EnemyController)target;
        int originalSize = boop.spawns.Count;
        if (newSize < originalSize)
        {
            if (newSize == 0)
            {
                boop.spawns = new List<GameObject>();
                boop.splines = new List<BezierSpline>();
                boop.spawnTimes = new List<float>();
            }
            boop.splines.RemoveRange(newSize - 1, originalSize - newSize-1);
            boop.spawnTimes.RemoveRange(newSize - 1, originalSize - newSize-1);
            boop.spawns.RemoveRange(newSize - 1, originalSize - newSize-1);
        }
        if (newSize > originalSize)
        {
            boop.spawnTimes.AddRange(new float[newSize - originalSize]);
            boop.splines.AddRange(new BezierSpline[newSize - originalSize]);
            boop.spawns.AddRange(new GameObject[newSize - originalSize]);
        }

    }
    public override void OnInspectorGUI()
    {
        EnemyController boop = (EnemyController)target;
        EditorGUILayout.LabelField("Enemies");
        int arraySize = EditorGUILayout.IntField("Size", boop.spawns.Count);
        changeArraySize(arraySize);
        scrollPosition=EditorGUILayout.BeginScrollView(scrollPosition);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Spawn", GUILayout.Width((EditorGUIUtility.currentViewWidth - 134) / 2));
        EditorGUILayout.LabelField("Spline", GUILayout.Width((EditorGUIUtility.currentViewWidth - 134) / 2));
        EditorGUILayout.LabelField("Time", GUILayout.Width(50));
        EditorGUILayout.LabelField("", GUILayout.Width(40));
        EditorGUILayout.EndHorizontal();
        for (int i=0; i < arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            boop.spawns[i] = (GameObject)EditorGUILayout.ObjectField("", boop.spawns[i],typeof(GameObject),false,GUILayout.Width((EditorGUIUtility.currentViewWidth-134)/2));
            boop.splines[i] = (BezierSpline)EditorGUILayout.ObjectField("", boop.splines[i], typeof(BezierSpline),true, GUILayout.Width((EditorGUIUtility.currentViewWidth - 134) / 2));
            boop.spawnTimes[i] = EditorGUILayout.FloatField(boop.spawnTimes[i], GUILayout.Width(50));
            if (GUILayout.Button("✘", GUILayout.Width(20))){
                Undo.RecordObject(boop, "Removed Enemy");
                boop.spawns.RemoveAt(i);
                boop.spawnTimes.RemoveAt(i);
                boop.splines.RemoveAt(i);
                i -= 1;
                continue;
            }
            if (GUILayout.Button("〱", GUILayout.Width(20)))
            {
                Undo.RecordObject(boop, "Cloned Enemy");
                boop.spawns.Insert(i, boop.spawns[i]);
                boop.spawnTimes.Insert(i, boop.spawnTimes[i]);
                boop.splines.Insert(i, boop.splines[i]);
            }
            EditorGUILayout.EndHorizontal();   
        }
        if(GUILayout.Button("Add Enemy"))
        {
            Undo.RecordObject(boop, "Add Enemy");
            changeArraySize(++arraySize);
            EditorUtility.SetDirty(boop);
        }
        EditorGUILayout.EndScrollView();
       // base.OnInspectorGUI();
    }
}
