/**
 * @file
 * @brief SelectItemNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Main {
/**
 * @brief SelectItemNodeScriptCreateDescクラス
 */
public class SelectItemNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public UnityBase.Util.SCENE.MENU_STAGE_TYPE stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE;
    public System.Action<UnityBase.Scene.Ui.Menu.Main.SelectItemNodeScript> onClick = null;
}

/**
 * @brief SelectItemNodeScriptクラス
 */
public class SelectItemNodeScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new UnityBase.Scene.Ui.Menu.Main.SelectItemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.SCENE.MENU_STAGE_TYPE _stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE;
    private System.Action<UnityBase.Scene.Ui.Menu.Main.SelectItemNodeScript> _onClick = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_SELECT_ITEM_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._stageType = this.createDesc.stageType;
        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.SCENE.MENU_STAGE_NAME_MST_TEXT_ID_ARRAY[(int)this._stageType]));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Main.SelectItemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Main.SelectItemNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
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
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
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
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
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
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public UnityBase.Util.SCENE.MENU_STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }
}
}
}
