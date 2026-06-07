/**
 * @file
 * @brief InfoSelect2BoardNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief InfoSelect2BoardNodeScriptCreateDescクラス
 */
public class InfoSelect2BoardNodeScriptCreateDesc : Select2BoardNodeScriptCreateDesc
{
}

/**
 * @brief InfoSelect2BoardNodeScriptクラス
 */
public class InfoSelect2BoardNodeScript : Select2BoardNodeScript
{
    [SerializeField] private TMP_Text _backButtonNameText = null;

    public new InfoSelect2BoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_INFO_SELECT2_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_SELECT2);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.NONE);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.MENU) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.INFO));
        this._backButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BACK));

        {// Faq ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.FAQ);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.INFO_FAQ);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Staff ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.STAFF);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.INFO_STAFF);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// License ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.LICENSE);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.INFO_LICENSE);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// PrivacyPolicy ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.PRIVACY_POLICY);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.INFO_PRIVACY_POLICY);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
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
            this.SetCreateDesc(new InfoSelect2BoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as InfoSelect2BoardNodeScriptCreateDesc;

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
     * @brief OnBackButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnBackButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

        this._onCloseSelect2Board(this);

        return;
    }
}
}
}
