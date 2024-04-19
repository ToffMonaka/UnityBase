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
public class InitSubSceneNodeScriptCreateDesc : Lib.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief InitSubSceneNodeScriptクラス
 */
public class InitSubSceneNodeScript : Lib.Scene.SubSceneNodeScript
{
    [SerializeField] private TMP_Text _messageText = null;
    [SerializeField] private Image _openCloseFadeImage = null;

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
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.INIT_SUB_SCENE_NODE);
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
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
        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        this._UpdateProgress();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();

            this._openCloseFadeImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();

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
		    switch (this._updateProgressCount) {
		    case 0: {
                {// UserFile Create
                    UnityBase.Global.userFile.readDesc.data.filePath = Application.persistentDataPath + "/" + UnityBase.Util.FILE_PATH.USER;
                    UnityBase.Global.userFile.writeDesc.data.filePath = UnityBase.Global.userFile.readDesc.data.filePath;

                    if (Lib.Data.Util.IsExistFile(UnityBase.Global.userFile.readDesc.data.filePath)) {
                        UnityBase.Global.userFile.Read();
                    } else {
                        UnityBase.Global.userFile.Write();
                    }
                }

                ++this._updateProgressCount;

			    break;
		    }
		    default: {
                this.SetUpdateProgressType(4);

			    break;
		    }
		    }

			break;
		}
		case 4: {
            if (this._updateProgressElapsedTime >= 3.0f) {
                this.Close(1, 1);

                this.SetUpdateProgressType(5);
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
