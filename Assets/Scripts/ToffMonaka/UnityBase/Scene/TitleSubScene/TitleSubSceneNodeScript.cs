/**
 * @file
 * @brief TitleSubSceneNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;
using ToffMonaka.UnityBase.Sound;
using ToffMonaka.UnityBase.SelectSubScene;
using ToffMonaka.UnityBase.Scene.CoverSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.TitleSubScene {
/**
 * @brief TitleSubSceneNodeScriptCreateDescクラス
 */
public class TitleSubSceneNodeScriptCreateDesc : SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief TitleSubSceneNodeScriptクラス
 */
public class TitleSubSceneNodeScript : SubSceneNodeScript
{
    [SerializeField] private TMP_Text _startButtonNameText = null;
    [SerializeField] private TMP_Text _debugNameText = null;
    [SerializeField] private TMP_Text _companyNameText = null;
    [SerializeField] private TMP_Text _versionNameText = null;

    public new TitleSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TITLE_SUB_SCENE_NODE);
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

        this._debugNameText.gameObject.SetActive(Util.GetDebugFlag());
        this._companyNameText.SetText(Util.PROJECT.COMPANY_NAME);
        this._versionNameText.SetText("Version " + Util.PROJECT.VERSION_NAME);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new TitleSubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as TitleSubSceneNodeScriptCreateDesc;

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

        this._startButtonNameText.DOFade(0.0f, 1.0f).SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo).SetDelay(1.0f).SetLink(this._startButtonNameText.gameObject);

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

        SceneUtil.GetManager().PlaySoundBgm((int)SoundUtil.BGM_SOUND_INDEX.TITLE);

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
     * @brief OnStartButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnStartButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK);

        this.Close(1, (owner) =>
        {
            {// SelectSubSceneNodeScript Create
                var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB) as SelectSubSceneNodeScript;
                var script_create_desc = new SelectSubSceneNodeScriptCreateDesc();

                script.Create(script_create_desc);
                script.Open(1);
            }

            return;
        });

        return;
    }
}
}
}
