/**
 * @file
 * @brief PlaySceneNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief PlaySceneNodeScriptクラス
 */
public class PlaySceneNodeScript : ToffMonaka.Lib.Scene.SceneNodeScript
{
    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.ChangeSubScene("Assets/Resources2/prefab/TitleSubScene.prefab");

        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected override void _OnDeactivate()
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
