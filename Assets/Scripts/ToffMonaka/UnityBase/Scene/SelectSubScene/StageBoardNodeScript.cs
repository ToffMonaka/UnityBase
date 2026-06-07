/**
 * @file
 * @brief StageBoardNodeScriptファイル
 */

using System.Collections.Generic;
using UnityEngine;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Scene;

namespace ToffMonaka {
namespace UnityBase.SelectSubScene {
/**
 * @brief StageBoardNodeScriptCreateDescクラス
 */
public class StageBoardNodeScriptCreateDesc : BoardNodeScriptCreateDesc
{
    public System.Action<StageBoardNodeScript, SceneUtil.STAGE_TYPE> onOpenStage = null;
}

/**
 * @brief StageBoardNodeScriptクラス
 */
public class StageBoardNodeScript : BoardNodeScript
{
    [SerializeField] private GameObject _itemNode = null;

    public new StageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<StageBoardItemNodeScript> _itemNodeScriptContainer = new();
    private System.Action<StageBoardNodeScript, SceneUtil.STAGE_TYPE> _onOpenStage = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SELECT_STAGE_BOARD_ITEM_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SELECT_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SELECT_BOARD_TYPE.STAGE);
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

        this._onOpenStage = this.createDesc.onOpenStage;

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.STAGE));

        this._itemNode.SetActive(false);

        {// Test2D ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<StageBoardItemNodeScript>();
            var script_create_desc = new StageBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.TEST_2D);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStage(this, SceneUtil.STAGE_TYPE.TEST_2D);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Test3D ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<StageBoardItemNodeScript>();
            var script_create_desc = new StageBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.TEST_3D);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStage(this, SceneUtil.STAGE_TYPE.TEST_3D);

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
            this.SetCreateDesc(new StageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as StageBoardNodeScriptCreateDesc;

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
}
}
}
