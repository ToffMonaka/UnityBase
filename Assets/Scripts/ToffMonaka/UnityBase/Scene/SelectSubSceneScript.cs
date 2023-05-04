/**
 * @file
 * @brief SelectSubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneScriptクラス
 */
public class SelectSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
    }

    /**
     * @brief _OnRelease関数
     */
    protected override void _OnRelease()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        var canvas_node = this.GetCoreNode().transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetHolder().GetSceneScript().GetMainCamera();

        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        return;
    }
        
    /**
     * @brief _OnFirstUpdate関数
     */
    protected override void _OnFirstUpdate()
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

    /**
     * @brief _OnOpen関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnOpen()
    {
        return (0);
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        return;
    }

    /**
     * @brief OnTest2DButtonPointerClickEvent関数
     */
    public void OnTest2DButtonPointerClickEvent()
    {
        if (this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_2D_SUB_SCENE_PREFAB) >= 0) {
            var script = (ToffMonaka.UnityBase.Scene.Test2DSubSceneScript)this.GetHolder().GetSubSceneScript();

            script.Open();
        }

        return;
    }

    /**
     * @brief OnTest3DButtonPointerClickEvent関数
     */
    public void OnTest3DButtonPointerClickEvent()
    {
        if (this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_3D_SUB_SCENE_PREFAB) >= 0) {
            var script = (ToffMonaka.UnityBase.Scene.Test3DSubSceneScript)this.GetHolder().GetSubSceneScript();

            script.Open();
        }

        return;
    }
}
}
