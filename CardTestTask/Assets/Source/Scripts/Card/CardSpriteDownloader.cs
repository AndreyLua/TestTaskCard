using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CardSpriteDownloader : MonoBehaviour
{
    public static CardSpriteDownloader Instance { get; private set; }
    private string _link = "https://picsum.photos/300/200";

    #if UNITY_EDITOR
        [InitializeOnLoadMethod]
    #endif  
        [RuntimeInitializeOnLoadMethod]
    private static void PreInit()
    {
        CardSpriteDownloader cardSpriteDownloader = FindObjectOfType<CardSpriteDownloader>();
        if (cardSpriteDownloader == null)
            cardSpriteDownloader = new GameObject("CardSpriteDownloader").AddComponent<CardSpriteDownloader>();
        Instance = cardSpriteDownloader;
    }

    public IEnumerator LoadSprite(Action<Sprite> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_link);

        yield return request.SendWebRequest();

        if (request.isDone == false)
        {
            throw new Exception(request.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            callback?.Invoke(Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero));
        }
    }
}