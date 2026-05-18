/**
 * @file
 * @brief InfoStaffStageBoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief InfoStaffStageBoardNodeScriptCreateDescクラス
 */
public class InfoStaffStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief InfoStaffStageBoardNodeScriptクラス
 */
public class InfoStaffStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private float _scrollBarMinSize = 64.0f;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_INFO_STAFF_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_STAFF_STAGE);
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
        return (UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.INFO_STAFF);
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

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.INFO) + " > " + UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.STAFF));

        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        this._messageNode.SetActive(false);

        {// MessageNode Create
            string[] txt_ary;

		    switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		    case UnityBase.Util.LANGUAGE_TYPE.JAPANESE: {
                txt_ary = UnityBase.Scene.Ui.Menu.Side.StaffMessageUtil.JAPANESE_TEXT_ARRAY;

			    break;
		    }
		    default: {
                txt_ary = UnityBase.Scene.Ui.Menu.Side.StaffMessageUtil.ENGLISH_TEXT_ARRAY;

			    break;
		    }
		    }

            for (int txt_i = 0; txt_i < txt_ary.Length; ++txt_i) {
                var txt = (txt_i <= 0) ? txt_ary[txt_i] : "\n" + txt_ary[txt_i];
                var node = GameObject.Instantiate(this._messageNode, this._messageNode.transform.parent);

                node.GetComponent<TMP_Text>().SetText(txt);
                node.SetActive(true);
            }
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        this._UpdateScrollBarSize();

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
     * @brief OnScrollRectValueChanged関数
     * @param event_pos (event_position)
     */
    public void OnScrollRectValueChanged(Vector2 event_pos)
    {
        this._UpdateScrollBarSize();

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
     * @brief _UpdateScrollBarSize関数
     */
    private void _UpdateScrollBarSize()
    {
        if (this._scrollRect.vertical) {
            if (this._scrollRect.verticalScrollbar != null) {
                var min_size = 1.0f / this._scrollRect.viewport.rect.height * this._scrollBarMinSize;

                if (this._scrollRect.verticalScrollbar.size < min_size) {
                    this._scrollRect.verticalScrollbar.size = min_size;
                }
            }
        }

        return;
    }
}
}
}
