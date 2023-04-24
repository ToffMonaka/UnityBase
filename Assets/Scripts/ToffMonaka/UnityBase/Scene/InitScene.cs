/**
 * @file
 * @brief InitSceneファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSceneクラス
 */
public class InitScene : ToffMonaka.Lib.Scene.Scene
{
    /**
     * @brief _OnStart関数
     */
    protected override void _OnStart()
    {
        this._LoadSubScene("");

        this.Invoke(nameof(_ChangeScene), 3.0f);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief _ChangeScene関数
     */
    private void _ChangeScene()
    {
        SceneManager.LoadScene("PlayScene");

        return;
    }
}
}
