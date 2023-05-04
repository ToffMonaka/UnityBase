/**
 * @file
 * @brief TitleSubSceneScriptファイル
 */


using UnityEngine;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief TitleSubSceneScriptクラス
 */
public class TitleSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private TextMeshProUGUI _startButtonText = null;
    [SerializeField] private TextMeshProUGUI _companyNameText = null;
    [SerializeField] private TextMeshProUGUI _versionNameText = null;

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
     * @brief _OnRelease関数
     */
    protected override void _OnRelease()
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
        var canvas_node = this.GetCoreNode().transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetHolder().GetSceneScript().GetMainCamera();

        this._companyNameText.SetText(ToffMonaka.UnityBase.Constant.Util.COMPANY_NAME);
        this._versionNameText.SetText("Version " + ToffMonaka.UnityBase.Constant.Util.VERSION_NAME);

        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._startButtonText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart).SetLink(this._startButtonText.gameObject);

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
     * @brief _OnFirstUpdate関数
     */
    protected override void _OnFirstUpdate()
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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnOpen()
    {
        return (0);
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        return;
    }

    /**
     * @brief OnStartButtonPointerClickEvent関数
     */
    public void OnStartButtonPointerClickEvent()
    {
        if (this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB) >= 0) {
            var script = (ToffMonaka.UnityBase.Scene.SelectSubSceneScript)this.GetHolder().GetSubSceneScript();

            script.Open();
        }

        return;
    }
}
}
