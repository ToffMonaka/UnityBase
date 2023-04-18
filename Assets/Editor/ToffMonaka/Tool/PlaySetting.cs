﻿/**
 * @file
 * @brief PlaySettingファイル
 */


using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


namespace ToffMonaka.Tool {
/**
 * @brief PlaySettingクラス
 */
public class PlaySetting : EditorWindow
{
    private const int _START_SCENE_INDEX = 1;
    private const string _ASSETS_STRING = "Assets/";

    private string[] _startSceneArray = new string[0];
    private int _startSceneIndex = ToffMonaka.Tool.PlaySetting._START_SCENE_INDEX;

    /**
     * @brief ShowWindow関数
     */
    [MenuItem("Tools/Play Setting")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PlaySetting>("Play Setting");

        return;
    }

    /**
     * @brief OnGUI関数
     */
    public void OnGUI()
    {
        this._updateStartScene();

        this._startSceneIndex = EditorGUILayout.Popup("開始シーン", this._startSceneIndex, this._startSceneArray);

        SceneAsset start_scene = null;

        if (this._startSceneIndex == 0) {
            start_scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorSceneManager.GetActiveScene().path);
        } else {
            start_scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[this._startSceneIndex - 1].path);
        }

        if (start_scene != null) {
            EditorSceneManager.playModeStartScene = start_scene;
        } else {
            Debug.LogError("開始シーンがありません。");
        }

        return;
    }

    /**
     * @brief _updateStartScene関数
     */
    private void _updateStartScene()
    {
        this._startSceneArray = new string[EditorBuildSettings.scenes.Length + 1];
        this._startSceneArray[0] = "デフォルト";

        string scene_name = "";

        for (int scenes_i = 0; scenes_i < EditorBuildSettings.scenes.Length; ++scenes_i) {
            int path_str_index = EditorBuildSettings.scenes[scenes_i].path.IndexOf(ToffMonaka.Tool.PlaySetting._ASSETS_STRING);

            if (path_str_index >= 0) {
                scene_name = EditorBuildSettings.scenes[scenes_i].path.Substring(path_str_index + ToffMonaka.Tool.PlaySetting._ASSETS_STRING.Length).Replace("/", "\u2215");
            } else {
                scene_name = EditorBuildSettings.scenes[scenes_i].path.Replace("/", "\u2215");
            }

            this._startSceneArray[scenes_i + 1] = "" + scenes_i + ": " + scene_name;
        }

        if (this._startSceneIndex >= this._startSceneArray.Length) {
            this._startSceneIndex = 0;
        }

        return;
    }
}
}
