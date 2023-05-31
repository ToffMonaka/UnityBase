/**
 * @file
 * @brief TitleSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief TitleSubSceneScriptCreateDescクラス
 */
public class TitleSubSceneScriptCreateDesc : ToffMonaka.Lib.Scene.SubSceneScriptCreateDesc
{
}

/**
 * @brief TitleSubSceneScriptクラス
 */
public class TitleSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private Image _openCloseFadeImage = null;
    [SerializeField] private TextMeshProUGUI _startButtonText = null;
    [SerializeField] private TextMeshProUGUI _companyNameText = null;
    [SerializeField] private TextMeshProUGUI _versionNameText = null;
    [SerializeField] private GameObject _menuNode = null;

    public new ToffMonaka.UnityBase.Scene.TitleSubSceneScriptCreateDesc createDesc{get; private set;} = null;
    private Sequence _openCloseSequence = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public TitleSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.TITLE_SUB_SCENE);

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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        var canvas_node = this.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetManager().GetMainSceneScript().GetMainCamera();

        this._companyNameText.SetText(ToffMonaka.UnityBase.Constant.Util.COMPANY_NAME);
        this._versionNameText.SetText("Version " + ToffMonaka.UnityBase.Constant.Util.VERSION_NAME);

        {// MenuScript Create
            var script = this._menuNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._menuScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.TitleSubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlayBgm((int)ToffMonaka.UnityBase.Constant.Util.SOUND.BGM_INDEX.TITLE);

        this._startButtonText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart).SetDelay(1.0f).SetLink(this._startButtonText.gameObject);

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

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.AppendInterval(0.05f);
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));

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
		switch (this.GetOpenType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteOpen();

                this._openCloseFadeImage.gameObject.SetActive(false);
            }

			break;
		}
		default: {
            this.CompleteOpen();

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
		switch (this.GetCloseType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            this._openCloseSequence.AppendInterval(0.05f);

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
		switch (this.GetCloseType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteClose();

                {// StageSelectSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.STAGE_SELECT_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.StageSelectSubSceneScript;
                    var script_create_desc = new ToffMonaka.UnityBase.Scene.StageSelectSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }
            }

			break;
		}
		default: {
            this.CompleteClose();

			break;
		}
		}

        return;
    }

    /**
     * @brief OnStartButtonPointerClickEvent関数
     */
    public void OnStartButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK);

        this.Close(1);

        return;
    }
}
}
