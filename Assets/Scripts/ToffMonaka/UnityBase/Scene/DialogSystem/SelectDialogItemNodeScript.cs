/**
 * @file
 * @brief SelectDialogItemNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
/**
 * @brief SelectDialogItemNodeScriptCreateDescクラス
 */
public class SelectDialogItemNodeScriptCreateDesc : ToffMonaka.Tml.Scene.ObjectNodeScriptCreateDesc
{
    public SelectDialogItemExtension extension = null;
    public System.Action<SelectDialogItemNodeScript> onClick = null;
}

/**
 * @brief SelectDialogItemNodeScriptクラス
 */
public class SelectDialogItemNodeScript : ToffMonaka.Tml.Scene.ObjectNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new SelectDialogItemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private SelectDialogItemExtension _extension = null;
    private System.Action<SelectDialogItemNodeScript> _onClick = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SELECT_DIALOG_ITEM_NODE);
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

        if (this.createDesc.extension == null) {
            return (-1);
        }

        this._extension = this.createDesc.extension;
        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(this._extension.OnGetName());

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SelectDialogItemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SelectDialogItemNodeScriptCreateDesc;

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        this._onClick?.Invoke(this);

        return;
    }

    /**
     * @brief GetExtension関数
     * @return ext (extension)
     */
    public SelectDialogItemExtension GetExtension()
    {
        return (this._extension);
    }
}
}
}
