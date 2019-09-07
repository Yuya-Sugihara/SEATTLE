using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シーン遷移時フェードイン、フェードアウトを行うクラス
/// </summary>
public class FadeManager : SingletonTemplate<FadeManager>
{
    public Color fadeColor { get; set; } = Color.white;
    private bool isFadeIn { get; set; }
    private bool isFadeOut { get; set; }

    [SerializeField]
    private float FadeTime = 0.2f;
    private float alpha = 1.0f;

    private Canvas FadeCanvas;
    private Image FadeImage;
    private GameSceneManager GameSceneManager;
    private GameSceneManager.GameScene NextGameScene;


    // Start is called before the first frame update
    void Start()
    { 
        GameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
        if (GameSceneManager == null)
        {
            Debug.Assert(false, "[FadeManager] start() GameSceneManager is not found.");
            return;
        }
    }

    private void initCanvasAndImage()
    { 
        //フェード用のCanvas生成
        GameObject FadeCanvasObject = new GameObject("CanvasFade");
        FadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        FadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        /// フェード用imageの作成
        FadeImage = new GameObject("FadeImage").AddComponent<Image>();
        FadeImage.transform.SetParent(FadeCanvas.transform, false);
        FadeImage.rectTransform.anchoredPosition = Vector3.zero;

        FadeImage.rectTransform.sizeDelta = new Vector2(9999, 9999);

    }

    // Update is called once per frame
    public void Update()
    {
        if(isFadeIn)
        {
            updateFadeIn();
        }
        else if(isFadeOut)
        {
            updateFadeOut();
        }
    }

    /// <summary>
    /// フェードイン呼び出し、初期設定を行う
    /// </summary>
    public void fadeIn()
    {
        if (FadeImage == null) initCanvasAndImage();

        FadeImage.color = fadeColor;
        isFadeIn = true;
    }

    /// <summary>
    /// フェードアウト呼び出し、初期設定を行う
    /// </summary>
    /// <param name="nextScene"></param>
    public void fadeOut(GameSceneManager.GameScene nextScene)
    {
        if (FadeImage == null) initCanvasAndImage();

        NextGameScene = nextScene;
        FadeImage.color = Color.clear;
        FadeCanvas.enabled = true;
        isFadeOut = true;
    }

    private void updateFadeIn()
    {
        alpha -= Time.deltaTime / FadeTime;
        if (alpha<=0.0f)
        {
            isFadeIn = false;
            alpha = 0.0f;
            FadeCanvas.enabled = false;
        }

        FadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
    }

    private void updateFadeOut()
    {
        //経過時間から透明度計算
        alpha += Time.deltaTime / FadeTime;

        //フェードアウト終了判定
        if (alpha >= 1.0f)
        {
            isFadeOut = false;
            alpha = 1.0f;

            //次のシーンへ遷移
            GameSceneManager.ChangeNextScene(NextGameScene);
        }

        //フェード用Imageの透明度設定
        //FadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        FadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
    }
}
