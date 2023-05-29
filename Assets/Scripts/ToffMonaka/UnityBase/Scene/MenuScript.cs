/**
 * @file
 * @brief MenuScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuScriptCreateDescクラス
 */
public class MenuScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
}

/**
 * @brief MenuScriptクラス
 */
public class MenuScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private Image _backgroundImage = null;
    [SerializeField] private GameObject _startButtonNode = null;
    [SerializeField] private GameObject _selectNode = null;
    [SerializeField] private GameObject _stageNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc createDesc{get; private set;} = null;
    private ToffMonaka.UnityBase.Scene.MenuStartButtonScript _startButtonScript = null;
    private ToffMonaka.UnityBase.Scene.MenuSelectScript _selectScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStageScript _stageScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU);

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
        this._backgroundImage.gameObject.SetActive(false);

        {// StartButtonScript Create
            var script = this._startButtonNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuStartButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuStartButtonScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._startButtonScript = script;
        }

        {// SelectScript Create
            var script = this._selectNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectScriptCreateDesc();

            script.Create(script_create_desc);

            this._selectScript = script;
        }

        {// StageScript Create
            var script = this._stageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuStageScriptCreateDesc();

            script.Create(script_create_desc);

            this._stageScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc;

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
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief ClickStartButton関数
     */
    public void ClickStartButton()
    {
        if (this._backgroundImage.gameObject.activeSelf) {
            this._backgroundImage.gameObject.SetActive(false);
        } else {
            this._backgroundImage.gameObject.SetActive(true);
        }

        return;
    }
}
}
