/**
 * @file
 * @brief OptionGraphicStageBoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief OptionGraphicStageBoardNodeScriptCreateDescクラス
 */
public class OptionGraphicStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionGraphicStageBoardNodeScriptクラス
 */
public class OptionGraphicStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private bool _restartFlag = false;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_OPTION_GRAPHIC_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_GRAPHIC_STAGE);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_GRAPHIC);
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

        this._nameText.SetText(DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.OPTION) + " > " + DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.GRAPHIC));

        this._okButtonNameText.SetText(DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScriptCreateDesc;

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

        this._scrollRect.verticalNormalizedPosition = 1.0f;

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
     * @brief OnOkButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        //DataUtil.systemConfigFile.Write(true);

        if (this._restartFlag) {
            UnityBase.Global.GetSceneManager().StartMainScene();
        } else {
            this._onCloseStageBoard(this);
        }

        return;
    }

    /**
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief _SetRestartFlag関数
     * @param restart_flg (restart_flag)
     */
    private void _SetRestartFlag(bool restart_flg)
    {
        this._restartFlag = restart_flg;

        if (this._restartFlag) {
            this._okButtonNameText.SetText(DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.OK) + "\n" + DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.RESTART));
            this._okButtonNameText.fontSize = 20.0f;
        } else {
            this._okButtonNameText.SetText(DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.OK));
            this._okButtonNameText.fontSize = 32.0f;
        }

        return;
    }
}
}
}
