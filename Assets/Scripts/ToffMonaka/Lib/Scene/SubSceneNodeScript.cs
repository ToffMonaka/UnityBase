/**
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

    private GameObject[] _canvasNodeArray = null;
    private GameObject _dialogNode = null;

    /**
     * @brief コンストラクタ
     */
    public SubSceneNodeScript() : base(Lib.Util.SCENE.SCRIPT_TYPE.SUB_SCENE_NODE, true)
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.SUB_SCENE_NODE);
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
     * @brief _OnSetNode関数
     */
    protected override void _OnSetNode()
    {
        const string canvas_name = "Canvas";
        const string dialog_name = "Dialog";

        this._canvasNodeArray = System.Array.Empty<GameObject>();

        var canvas_transform = this.transform.Find(canvas_name);

    	while (canvas_transform != null) {
            Lib.Array.Util.Resize(ref this._canvasNodeArray, this._canvasNodeArray.Length + 1, canvas_transform.gameObject);

            canvas_transform = this.transform.Find(canvas_name + (this._canvasNodeArray.Length + 1));
        }

        for (int canvas_node_i = 0; canvas_node_i < this._canvasNodeArray.Length; ++canvas_node_i) {
            var canvas_node = this._canvasNodeArray[canvas_node_i];
            var canvas = canvas_node.GetComponent<Canvas>();

            canvas.worldCamera = this.GetManager().GetMainSceneNodeScript().GetMainCamera();

            if (canvas_node_i > 0) {
                canvas.sortingLayerName = canvas.sortingLayerName + (canvas_node_i + 1);
            }

            var dialog_transform = canvas_node.transform.Find(dialog_name);

            if (dialog_transform != null) {
                this._dialogNode = dialog_transform.gameObject;
            }
        }

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
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
     * @brief GetCanvasNodeArray関数
     * @return canvas_node_ary (canvas_node_array)
     */
    public GameObject[] GetCanvasNodeArray()
    {
        return (this._canvasNodeArray);
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
