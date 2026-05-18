/**
 * @file
 * @brief SelectDialogItemNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief SelectDialogItemNodeScriptCreateDescクラス
 */
public class SelectDialogItemNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.Dialog.SelectDialogItemEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript> onClick = null;
}

/**
 * @brief SelectDialogItemNodeScriptクラス
 */
public class SelectDialogItemNodeScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Dialog.SelectDialogItemEngine _engine = null;
    private System.Action<UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript> _onClick = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_DIALOG_ITEM_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        if (this.createDesc.engine == null) {
            return (-1);
        }

        this._engine = this.createDesc.engine;
        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(this._engine.OnGetName());

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._onClick?.Invoke(this);

        return;
    }

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.Dialog.SelectDialogItemEngine GetEngine()
    {
        return (this._engine);
    }
}
}
}
