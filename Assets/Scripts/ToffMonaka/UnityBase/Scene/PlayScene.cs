/**
 * @file
 * @brief PlaySceneファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSceneクラス
 */
public class PlayScene : ToffMonaka.Lib.Scene.Scene
{
    /**
     * @brief _OnStart関数
     */
    protected override void _OnStart()
    {
        this._LoadSubScene("Assets/Resources2/prefab/TitleSubScene.prefab");

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }
}
}
