using System;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

namespace RankedPlaylistLoader
{
    public class Utils
    {
        public static IEnumerator DownloadFile(string uri, string outputPath)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError) yield break;

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(outputPath))) Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    File.WriteAllBytes(outputPath, request.downloadHandler.data);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
