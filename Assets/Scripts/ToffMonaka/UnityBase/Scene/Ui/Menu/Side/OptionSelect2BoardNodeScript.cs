/**
 * @file
 * @brief OptionSelect2BoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief OptionSelect2BoardNodeScriptCreateDescクラス
 */
public class OptionSelect2BoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionSelect2BoardNodeScriptクラス
 */
public class OptionSelect2BoardNodeScript : UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScript
{
    [SerializeField] private TMP_Text _backButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_OPTION_SELECT2_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SELECT2);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.MENU) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION));
        this._backButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BACK));

        {// System ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.SYSTEM);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SYSTEM);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Input ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.INPUT);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_INPUT);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Graphic ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.GRAPHIC);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_GRAPHIC);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Sound ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.SOUND);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SOUND);

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
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScriptCreateDesc;

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
