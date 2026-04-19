/**
 * @file
 * @brief InitSubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief InitSubSceneNodeScriptCreateDescクラス
 */
public class InitSubSceneNodeScriptCreateDesc : UnityBase.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief InitSubSceneNodeScriptクラス
 */
public class InitSubSceneNodeScript : UnityBase.Scene.SubSceneNodeScript
{
    [SerializeField] private TMP_Text _messageText = null;

    public new UnityBase.Scene.InitSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private int _updateProgressType = 0;
    private int _updateProgressCount = 0;
    private float _updateProgressElapsedTime = 0.0f;

    /**
     * @brief コンストラクタ
     */
    public InitSubSceneNodeScript()
    {
        return;
    }
    
    /**
     * @brief _OnGetNodeScriptIndex関数
     * @return node_script_index (node_script_index)
     */
    protected override int _OnGetNodeScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.INIT_SUB_SCENE);
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

		switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		case UnityBase.Util.LANGUAGE_TYPE.JAPANESE: {
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
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.InitSubSceneNodeScriptCreateDesc;

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
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

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
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

		switch (this.GetClosedType()) {
        case 1: {
            {// TitleSubSceneNodeScript Create
                var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneNodeScript;
                var script_create_desc = new UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc();

                script.Create(script_create_desc);
                script.Open(1);
            }

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
		            switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		            case UnityBase.Util.LANGUAGE_TYPE.JAPANESE: {
                        UnityBase.Global.mstTextTableFile.readDesc.data.filePath = UnityBase.Util.FILE_PATH.JAPANESE_MST_TEXT_TABLE;

			            break;
		            }
		            default: {
                        UnityBase.Global.mstTextTableFile.readDesc.data.filePath = UnityBase.Util.FILE_PATH.ENGLISH_MST_TEXT_TABLE;

			            break;
		            }
		            }

                    UnityBase.Global.mstTextTableFile.readDesc.data.addressablesFlag = true;

                    UnityBase.Global.mstTextTableFile.Read();
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
                this.Close(1, 1);

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
