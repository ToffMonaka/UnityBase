/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Stage.Test3D {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SubSceneNodeScriptクラス
 */
public class SubSceneNodeScript : UnityBase.Scene.Stage.SubSceneNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _messageText = null;

    public new UnityBase.Scene.Stage.Test3D.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.TEST_3D_STAGE_SUB_SCENE_NODE);
    }

    /**
     * @brief _OnGetStageType関数
     * @return stage_type (stage_type)
     */
    protected override UnityBase.Util.SCENE.STAGE_TYPE _OnGetStageType()
    {
        return (UnityBase.Util.SCENE.STAGE_TYPE.TEST_3D);
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

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.TEST_3D));
        this._messageText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.IN_PREPARATION));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Stage.Test3D.SubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Stage.Test3D.SubSceneNodeScriptCreateDesc;

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

		switch (this.GetOpenType()) {
		case 1: {
            {// SimpleCover Add
                var script_create_desc = new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc();

                script_create_desc.color = new Color32(8, 8, 8, 255);
                script_create_desc.playTime = 0.2f;
                script_create_desc.waitTime = 0.05f;
                script_create_desc.reverseFlag = false;

                this.GetCoverSystemNodeScript().AddCover(script_create_desc);
            }

            this.AddOpenCloseChecker((owner) =>
            {
                return (this.GetCoverSystemNodeScript().IsPlay());
            });

			break;
		}
		default: {
			break;
		}
		}

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

		switch (this.GetCloseType()) {
		case 1: {
            {// SimpleCover Add
                var script_create_desc = new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc();

                script_create_desc.color = new Color32(8, 8, 8, 255);
                script_create_desc.playTime = 0.2f;
                script_create_desc.waitTime = 0.05f;
                script_create_desc.reverseFlag = true;

                this.GetCoverSystemNodeScript().AddCover(script_create_desc);
            }

            this.AddOpenCloseChecker((owner) =>
            {
                return (this.GetCoverSystemNodeScript().IsPlay());
            });

			break;
		}
		default: {
			break;
		}
		}

        return;
    }
}
}
}
