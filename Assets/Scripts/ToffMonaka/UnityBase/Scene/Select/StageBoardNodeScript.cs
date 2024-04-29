/**
 * @file
 * @brief StageBoardNodeScriptファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
/**
 * @brief StageBoardNodeScriptCreateDescクラス
 */
public class StageBoardNodeScriptCreateDesc : UnityBase.Scene.Select.BoardNodeScriptCreateDesc
{
    public System.Action<UnityBase.Scene.Select.StageBoardNodeScript, UnityBase.Scene.Select.StageBoardItemNodeScript> onClickItem = null;
}

/**
 * @brief StageBoardNodeScriptクラス
 */
public class StageBoardNodeScript : UnityBase.Scene.Select.BoardNodeScript
{
    [SerializeField] private GameObject _itemNode = null;

    public new UnityBase.Scene.Select.StageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<UnityBase.Scene.Select.StageBoardItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Select.StageBoardItemNodeScript>();
    private System.Action<UnityBase.Scene.Select.StageBoardNodeScript, UnityBase.Scene.Select.StageBoardItemNodeScript> _onClickItem = null;

    /**
     * @brief コンストラクタ
     */
    public StageBoardNodeScript() : base(UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE)
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_STAGE_BOARD_NODE);
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

        this._onClickItem = this.createDesc.onClickItem;

        this._itemNode.SetActive(false);

        {// ItemNodeScript Create
            UnityBase.Util.SCENE.STAGE_TYPE[] stage_type_ary = {
                UnityBase.Util.SCENE.STAGE_TYPE.TEST_2D,
                UnityBase.Util.SCENE.STAGE_TYPE.TEST_3D
            };

            void on_click(UnityBase.Scene.Select.StageBoardItemNodeScript owner)
            {
                this._onClickItem?.Invoke(this, owner);

                return;
            }

            foreach (var stage_type in stage_type_ary) {
                var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Select.StageBoardItemNodeScript>();
                var script_create_desc = new UnityBase.Scene.Select.StageBoardItemNodeScriptCreateDesc();

                script_create_desc.stageType = stage_type;
                script_create_desc.onClick = on_click;

                script.Create(script_create_desc);
                script.Open(0);

                this._itemNodeScriptContainer.Add(script);
            }
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Select.StageBoardNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

        return;
    }
}
}
}
