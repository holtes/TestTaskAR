using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Model : MonoBehaviour
{
    public static int score
    {
        get
        {
            if (!PlayerPrefs.HasKey("score"))
            {
                PlayerPrefs.SetInt("score", 57);
            }
            return PlayerPrefs.GetInt("score");
        }
        set
        {
            PlayerPrefs.SetInt("score", value);
        }

    }


}

//[CustomEditor(typeof(ViewController))]
//public class customButton : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        ViewController myScript = (ViewController)target;
//        if (GUILayout.Button("Save Score"))
//        {
//            myScript.SaveScore();
//        }
//    }

//}
