/**
 * @file
 * @brief InfoPrivacyPolicyStageBoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief InfoPrivacyPolicyStageBoardNodeScriptCreateDescクラス
 */
public class InfoPrivacyPolicyStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief InfoPrivacyPolicyStageBoardNodeScriptクラス
 */
public class InfoPrivacyPolicyStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private float _scrollBarMinSize = 64.0f;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_INFO_PRIVACY_POLICY_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_PRIVACY_POLICY_STAGE);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.INFO_PRIVACY_POLICY);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.INFO) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.PRIVACY_POLICY));

        this._cancelButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.CANCEL));

        this._messageNode.SetActive(false);

        {// MessageNode Create
            string[] txt_ary;

		    switch (DataUtil.systemConfigFile.data.systemLanguageType) {
		    case Util.LANGUAGE_TYPE.JAPANESE: {
                txt_ary = UnityBase.Scene.Ui.Menu.Side.PrivacyPolicyMessageUtil.JAPANESE_TEXT_ARRAY;

			    break;
		    }
		    default: {
                txt_ary = UnityBase.Scene.Ui.Menu.Side.PrivacyPolicyMessageUtil.ENGLISH_TEXT_ARRAY;

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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScriptCreateDesc;

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

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
