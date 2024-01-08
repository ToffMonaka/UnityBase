﻿/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : Lib.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief SubScenScripteクラス
 */
public abstract class SubSceneNodeScript : Lib.Scene.NodeScript
{
    public new Lib.Scene.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private GameObject _canvasNode = null;
    private GameObject _dialogNode = null;

    /**
     * @brief コンストラクタ
     * @param script_index (script_index)
     */
    public SubSceneNodeScript(int script_index) : base(Lib.Util.SCENE.SCRIPT_TYPE.SUB_SCENE, script_index, true)
    {
        return;
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        base._Awake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        base._Destroy();

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.SubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        base._Active();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        base._Deactive();

        return;
    }

    /**
     * @brief _FirstUpdate関数
     */
    protected override void _FirstUpdate()
    {
        base._FirstUpdate();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        base._Update();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        base._FixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        base._LateUpdate();

        return;
    }

    /**
     * @brief GetCanvasNode関数
     * @return canvas_node (canvas_node)
     */
    public GameObject GetCanvasNode()
    {
        return (this._canvasNode);
    }

    /**
     * @brief _SetCanvasNode関数
     */
    protected override void _SetCanvasNode()
    {
        var canvas_transform = this.transform.Find("Canvas");

        if (canvas_transform != null) {
            this._canvasNode = canvas_transform.gameObject;

            this._canvasNode.GetComponent<Canvas>().worldCamera = this.GetManager().GetMainSceneScript().GetMainCamera();

            var dialog_transform = canvas_transform.Find("Dialog");

            if (dialog_transform != null) {
                this._dialogNode = dialog_transform.gameObject;
            }
        }

        return;
    }

    /**
     * @brief GetDialogNode関数
     * @return dialog_node (dialog_node)
     */
    public GameObject GetDialogNode()
    {
        return (this._dialogNode);
    }
}
}
}
