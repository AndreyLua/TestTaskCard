using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class CardSpriteDownloader : MonoBehaviour
{
    private string _link = "https://picsum.photos/300/200";

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