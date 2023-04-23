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
     * @brief OnStart関数
     */
    protected override void OnStart()
    {
        this.Invoke(nameof(_changeScene), 3.0f);

        return;
    }

    /**
     * @brief OnUpdate関数
     */
    protected override void OnUpdate()
    {
        return;
    }

    /**
     * @brief _changeScene関数
     */
    private void _changeScene()
    {
        SceneManager.LoadScene("PlayScene");

        return;
    }
}
}
