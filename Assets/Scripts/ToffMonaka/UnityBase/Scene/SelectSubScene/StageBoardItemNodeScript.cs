/**
 * @file
 * @brief StageBoardItemNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Sound;
using ToffMonaka.UnityBase.Scene;

namespace ToffMonaka {
namespace UnityBase.SelectSubScene {
/**
 * @brief StageBoardItemNodeScriptCreateDescクラス
 */
public class StageBoardItemNodeScriptCreateDesc : ToffMonaka.Tml.Scene.ObjectNodeScriptCreateDesc
{
    public string name = "";
    public System.Action<StageBoardItemNodeScript> onClick = null;
}

/**
 * @brief StageBoardItemNodeScriptクラス
 */
public class StageBoardItemNodeScript : ToffMonaka.Tml.Scene.ObjectNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new StageBoardItemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private System.Action<StageBoardItemNodeScript> _onClick = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SELECT_STAGE_BOARD_ITEM_NODE);
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

        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(this.createDesc.name);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new StageBoardItemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as StageBoardItemNodeScriptCreateDesc;

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
}
}
}
