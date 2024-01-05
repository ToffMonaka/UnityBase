/**
 * @file
 * @brief InitSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief InitSubSceneScriptCreateDescクラス
 */
public class InitSubSceneScriptCreateDesc : Lib.Scene.SubSceneScriptCreateDesc
{
}

/**
 * @brief InitSubSceneScriptクラス
 */
public class InitSubSceneScript : Lib.Scene.SubSceneScript
{
    [SerializeField] private TMP_Text _messageText = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.InitSubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private int _progressType = 0;
    private int _progressCount = 0;
    private float _progressElapsedTime = 0.0f;

    /**
     * @brief コンストラクタ
     */
    public InitSubSceneScript()
    {
        this._SetScriptIndex((int)UnityBase.Util.SCENE.SCRIPT_INDEX.INIT_SUB_SCENE);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.InitSubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this.SetProgressType(1);

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
		switch (this._progressType) {
		case 1: {
            this._progressElapsedTime += Time.deltaTime;

            this.SetProgressType(2);

			break;
		}
		case 2: {
            this._progressElapsedTime += Time.deltaTime;

		    switch (this._progressCount) {
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

                ++this._progressCount;

			    break;
		    }
		    default: {
                this.SetProgressType(3);

			    break;
		    }
		    }

			break;
		}
		case 3: {
            this._progressElapsedTime += Time.deltaTime;

            if (this._progressElapsedTime >= 3.0f) {
                this.Close(1, 1);

                this.SetProgressType(4);
            }

			break;
		}
		default: {
			break;
		}
		}

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
                {// TitleSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneScript;
                    var script_create_desc = new UnityBase.Scene.TitleSubSceneScriptCreateDesc();

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
     * @brief GetProgressType関数
     * @return progress_type (progress_type)
     */
    public int GetProgressType()
    {
        return (this._progressType);
    }

    /**
     * @brief SetProgressType関数
     * @param progress_type (progress_type)
     */
    public void SetProgressType(int progress_type)
    {
        this._progressType = progress_type;
        this._progressCount = 0;
        this._progressElapsedTime = 0.0f;

        return;
    }
}
}
}
