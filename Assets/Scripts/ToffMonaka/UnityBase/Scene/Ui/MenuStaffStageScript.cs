﻿/**
 * @file
 * @brief MenuStaffStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuStaffStageScriptCreateDescクラス
 */
public class MenuStaffStageScriptCreateDesc : UnityBase.Scene.Ui.MenuStageScriptCreateDesc
{
}

/**
 * @brief MenuStaffStageScriptクラス
 */
public class MenuStaffStageScript : UnityBase.Scene.Ui.MenuStageScript
{
    [SerializeField] private ScrollRect _messageScrollRect = null;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.MenuStaffStageScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public MenuStaffStageScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_STAFF_STAGE);
        this._SetStageType(UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.STAFF);

        return;
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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        this._messageNode.SetActive(false);

        {// MessageNode Create
            var en_str_ary = new string[]{
                "-SCENARIO-\n" +
                "Toff Monaka",
    
                "-PROGRAM-\n" +
                "Toff Monaka",
    
                "-GRAPHIC-\n" +
                "Toff Monaka",
    
                "-SOUND-\n" +
                "Toff Monaka\n" +
                "無料効果音で遊ぼう！/無料効果音素材\n" +
                "http://taira-komori.jpn.org/freesound.html\n" +
                "©効果音ラボ\n" +
                "https://soundeffect-lab.info/\n" +
                "On-Jin ～音人～\n" +
                "https://on-jin.com/\n" +
                "甘茶の音楽工房\n" +
                "http://amachamusic.chagasi.com/"
            };
            var jp_str_ary = new string[]{
                "-シナリオ-\n" +
                "Toff Monaka",
    
                "-プログラム-\n" +
                "Toff Monaka",
    
                "-グラフィック-\n" +
                "Toff Monaka",
    
                "-サウンド-\n" +
                "Toff Monaka\n" +
                "無料効果音で遊ぼう！/無料効果音素材\n" +
                "http://taira-komori.jpn.org/freesound.html\n" +
                "©効果音ラボ\n" +
                "https://soundeffect-lab.info/\n" +
                "On-Jin ～音人～\n" +
                "https://on-jin.com/\n" +
                "甘茶の音楽工房\n" +
                "http://amachamusic.chagasi.com/"
            };
            string[] str_ary;

		    switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		    case UnityBase.Constant.Util.LANGUAGE_TYPE.JAPANESE: {
                str_ary = jp_str_ary;

			    break;
		    }
		    default: {
                str_ary = en_str_ary;

			    break;
		    }
		    }

            for (int str_i = 0; str_i < str_ary.Length; ++str_i) {
                var str = (str_i <= 0) ? str_ary[str_i] : "\n" + str_ary[str_i];

                var node = GameObject.Instantiate(this._messageNode, this._messageNode.transform.parent);

                node.GetComponent<TMP_Text>().SetText(str);

                node.SetActive(true);
            }
        }

        this._cancelButtonNameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuStaffStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._messageScrollRect.verticalNormalizedPosition = 1.0f;
        this._cancelButtonCoverImage.gameObject.SetActive(false);

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

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

        return;
    }

    /**
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this.GetMenuScript().RunStageCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerExit(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
}