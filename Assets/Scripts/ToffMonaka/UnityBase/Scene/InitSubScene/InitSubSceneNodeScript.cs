/**
 * @file
 * @brief InitSubSceneNodeScriptファイル
 */

using UnityEngine;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Scene.TitleSubScene;
using ToffMonaka.UnityBase.Scene.CoverSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.InitSubScene {
/**
 * @brief InitSubSceneNodeScriptCreateDescクラス
 */
public class InitSubSceneNodeScriptCreateDesc : SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief InitSubSceneNodeScriptクラス
 */
public class InitSubSceneNodeScript : SubSceneNodeScript
{
    [SerializeField] private TMP_Text _messageText = null;

    public new InitSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private int _updateProgressType = 0;
    private int _updateProgressCount = 0;
    private float _updateProgressElapsedTime = 0.0f;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.INIT_SUB_SCENE_NODE);
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

		switch (DataUtil.systemConfigFile.data.systemLanguageType) {
		case Util.LANGUAGE_TYPE.JAPANESE: {
            this._messageText.SetText("ちょっと待ってね。");

			break;
		}
		default: {
            this._messageText.SetText("Please wait a second.");

			break;
		}
		}

        this.SetUpdateProgressType(1);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new InitSubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as InitSubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        this._UpdateProgress();

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
                var script_create_desc = new SimpleCoverNodeScriptCreateDesc();

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
                var script_create_desc = new SimpleCoverNodeScriptCreateDesc();

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

    /**
     * @brief GetUpdateProgressType関数
     * @return update_progress_type (update_progress_type)
     */
    public int GetUpdateProgressType()
    {
        return (this._updateProgressType);
    }

    /**
     * @brief SetUpdateProgressType関数
     * @param update_progress_type (update_progress_type)
     */
    public void SetUpdateProgressType(int update_progress_type)
    {
        this._updateProgressType = update_progress_type;
        this._updateProgressCount = 0;
        this._updateProgressElapsedTime = 0.0f;

        return;
    }

    /**
     * @brief _UpdateProgress関数
     */
    private void _UpdateProgress()
    {
        if (this._updateProgressType == 0) {
            return;
        }

        this._updateProgressElapsedTime += Time.deltaTime;

		switch (this._updateProgressType) {
		case 1: {
            this.SetUpdateProgressType(2);

			break;
		}
		case 2: {
		    switch (this._updateProgressCount) {
		    case 0: {
                {// MstTextTableFile Create
		            switch (DataUtil.systemConfigFile.data.systemLanguageType) {
		            case Util.LANGUAGE_TYPE.JAPANESE: {
                        DataUtil.mstTextTableFile.readDesc.data.filePath = Util.FILE_PATH.JAPANESE_MST_TEXT_TABLE;

			            break;
		            }
		            default: {
                        DataUtil.mstTextTableFile.readDesc.data.filePath = Util.FILE_PATH.ENGLISH_MST_TEXT_TABLE;

			            break;
		            }
		            }

                    DataUtil.mstTextTableFile.readDesc.data.addressablesFlag = true;

                    DataUtil.mstTextTableFile.Read();
                }

                ++this._updateProgressCount;

			    break;
		    }
		    default: {
                this.SetUpdateProgressType(3);

			    break;
		    }
		    }

			break;
		}
		case 3: {
            if (this._updateProgressElapsedTime >= 3.0f) {
                this.Close(1, (owner) =>
                {
                    {// TitleSubSceneNodeScript Create
                        var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as TitleSubSceneNodeScript;
                        var script_create_desc = new TitleSubSceneNodeScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

                    return;
                });

                this.SetUpdateProgressType(4);
            }

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
