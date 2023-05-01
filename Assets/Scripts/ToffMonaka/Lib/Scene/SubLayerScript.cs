/**
 * @file
 * @brief LayerScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief LayerScriptクラス
 */
public abstract class LayerScript : ToffMonaka.Lib.Scene.Script
{
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
     * @brief Create関数
     * @param sub_scene_script (sub_scene_script)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.SubSceneScript sub_scene_script)
    {
        if (sub_scene_script == null) {
            return (-1);
        }

        this.SetHolder(sub_scene_script.GetHolder());

        return (0);
    }
}
}
