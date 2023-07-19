/**
 * @file
 * @brief TitleSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    [SerializeField] private TMP_Text _startButtonNameText = null;
    [SerializeField] private TMP_Text _companyNameText = null;
    [SerializeField] private TMP_Text _versionNameText = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new ToffMonaka.UnityBase.Scene.TitleSubSceneScriptCreateDesc createDesc{get; private set;} = null;

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

        this._startButtonNameText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart).SetDelay(1.0f).SetLink(this._startButtonNameText.gameObject);

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

            {// StageSelectSubSceneScript Create
                var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.STAGE_SELECT_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.StageSelectSubSceneScript;
                var script_create_desc = new ToffMonaka.UnityBase.Scene.StageSelectSubSceneScriptCreateDesc();

                script.Create(script_create_desc);
                script.Open(1);
            }
        }

        return;
    }

    /**
     * @brief OnStartButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnStartButtonPointerClick(BaseEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK);

        this.Close(1);

        return;
    }
}
}
