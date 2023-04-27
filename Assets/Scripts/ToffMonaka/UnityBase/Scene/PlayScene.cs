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
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this._CreateSubScene("Assets/Resources2/prefab/TitleSubScene.prefab");

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
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
