/**
 * @file
 * @brief ExitStageBoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief ExitStageBoardNodeScriptCreateDescクラス
 */
public class ExitStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief ExitStageBoardNodeScriptクラス
 */
public class ExitStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _backToTitleNameText = null;
    [SerializeField] private Toggle _backToTitleToggle = null;
    [SerializeField] private TMP_Text _exitNameText = null;
    [SerializeField] private Toggle _exitToggle = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_EXIT_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.EXIT_STAGE);
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
        return (UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.EXIT);
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

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.EXIT));

        this._backToTitleNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.BACK_TO_TITLE));
        this._exitNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.EXIT));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScriptCreateDesc;

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
        this._backToTitleToggle.SetIsOnWithoutNotify(false);
        this._exitToggle.SetIsOnWithoutNotify(false);

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
     * @brief OnBackToTitleToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnBackToTitleToggleValueChanged(bool event_val)
    {
        if (this._backToTitleToggle.isOn) {
            this._exitToggle.SetIsOnWithoutNotify(false);
        }

        if (!this.IsControllable()) {
            return;
        }

        if (this._backToTitleToggle.isOn) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

        return;
    }

    /**
     * @brief OnExitToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnExitToggleValueChanged(bool event_val)
    {
        if (this._exitToggle.isOn) {
            this._backToTitleToggle.SetIsOnWithoutNotify(false);
        }

        if (!this.IsControllable()) {
            return;
        }

        if (this._exitToggle.isOn) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

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

        if (this._backToTitleToggle.isOn) {
            UnityBase.Global.GetSceneManager().GetSubSceneNodeScript().Close(1, (owner) =>
            {
                {// TitleSubSceneNodeScript Create
                    var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneNodeScript;
                    var script_create_desc = new UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

                return;
            });
        } else if (this._exitToggle.isOn) {
            UnityBase.Global.GetSceneManager().EndMainScene();
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
}
}
}
