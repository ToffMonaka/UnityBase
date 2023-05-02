/**
 * @file
 * @brief SubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SubScenScripteクラス
 */
public abstract class SubSceneScript : ToffMonaka.Lib.Scene.Script
{
    /**
     * @brief コンストラクタ
     */
    public SubSceneScript()
    {
        this._SetScriptType((int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE);

        return;
    }

    /**
     * @brief _OnActivate2関数
     */
    protected override void _OnActivate2()
    {
        return;
    }

    /**
     * @brief _OnDeactivate2関数
     */
    protected override void _OnDeactivate2()
    {
        return;
    }

    /**
     * @brief _OnUpdate2関数
     */
    protected override void _OnUpdate2()
    {
        return;
    }

    /**
     * @brief _OnDelete2関数
     */
    protected override void _OnDelete2()
    {
        return;
    }

    /**
     * @brief Create関数
     * @param scene_script (scene_script)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.SceneScript scene_script)
    {
        if (scene_script == null) {
            return (-1);
        }

        this._SetHolder(scene_script.GetHolder());

        this.gameObject.transform.parent = scene_script.subSceneLayoutNode.transform;

        var canvas_node = this.gameObject.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = scene_script.mainCamera;

        return (0);
    }
}
}
