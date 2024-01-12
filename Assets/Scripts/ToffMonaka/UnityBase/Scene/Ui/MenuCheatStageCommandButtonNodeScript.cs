/**
 * @file
 * @brief MenuCheatStageCommandButtonNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuCheatStageCommandButtonNodeScriptCreateDescクラス
 */
public class MenuCheatStageCommandButtonNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.MenuCheatStageNodeScript stageNodeScript = null;
    public UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE commandType = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;
}

/**
 * @brief MenuCheatStageCommandButtonNodeScriptクラス
 */
public class MenuCheatStageCommandButtonNodeScript : Lib.Scene.ObjectNodeScript, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _detailText = null;
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuCheatStageNodeScript _stageNodeScript = null;
    private UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE _commandType = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageCommandButtonNodeScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.MENU_CHEAT_STAGE_COMMAND_BUTTON)
    {
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
        this._stageNodeScript = this.createDesc.stageNodeScript;
        this._commandType = this.createDesc.commandType;

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_NAME_MST_TEXT_ID_ARRAY[(int)this._commandType]));

        var param = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY[(int)this._commandType];

        if (param.Length > 0) {
            this._detailText.SetText(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)this._commandType] + " " + param);
        } else {
            this._detailText.SetText(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)this._commandType]);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._coverImage.gameObject.SetActive(false);

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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._stageNodeScript.RunCommandButton(this._commandType);

        return;
    }

    /**
     * @brief OnPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        this._coverImage.gameObject.SetActive(false);

        return;
    }
}
}
}
