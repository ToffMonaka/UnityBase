/**
 * @file
 * @brief InitSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSceneScriptクラス
 */
public class InitSceneScript : ToffMonaka.Lib.Scene.SceneScript
{
    private int _progressType = 0;
    private float _progressElapsedTime = 0.0f;

    /**
     * @brief コンストラクタ
     */
    public InitSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.INIT_SCENE);

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.Create(new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT));
        this.ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.NONE);

        this._progressType = 1;
        this._progressElapsedTime = 0.0f;

        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected override void _OnDeactivate()
    {
        this.Delete();

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

            if (this._progressElapsedTime >= 3.0f) {
                this.ChangeScene(ToffMonaka.UnityBase.Constant.Util.SCENE_NAME.PLAY_SCENE);

                this._progressType = 2;
                this._progressElapsedTime = 0.0f;
            }

			break;
		}
		case 2: {
			break;
		}
		}

        return;
    }

    /**
     * @brief _OnDelete関数
     */
    protected override void _OnDelete()
    {
        return;
    }
}
}
