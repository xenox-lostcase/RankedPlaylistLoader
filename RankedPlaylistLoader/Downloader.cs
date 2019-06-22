using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace RankedPlaylistLoader
{
    class Downloader : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(Download());
        }

        IEnumerator Download()
        {
            var docPath = Application.dataPath;
            docPath = docPath.Substring(0, docPath.Length - 5);
            docPath = docPath.Substring(0, docPath.LastIndexOf("/"));
            var playlistPath = docPath + "/Playlists/";

            if (!Directory.Exists(playlistPath))
            {
                Directory.CreateDirectory(playlistPath);
            }

            var stars = new string[] {
                                        "3.00~3.49",
                                        "3.50~3.99",
                                        "4.00~4.99",
                                        "5.00~5.99",
                                        "6.00~6.99",
                                        "7.00~7.99",
                                        "8.00~8.99",
                                        "9.00~",
                                    };

            var counter = 0;

            foreach (var star in stars)
            {
                StartCoroutine(HelperEnumerator(Utils.DownloadFile($"https://raw.githubusercontent.com/xenox-lostcase/RankedStarPlaylists/master/Ranked{star}.json", $"{playlistPath}Ranked{star}.json"), () => counter++));
            }
            
            yield return new WaitUntil(() => counter == stars.Length);
            SongBrowserPlugin.DataAccess.PlaylistsCollection.ReloadPlaylists(false);
        }
        
        IEnumerator HelperEnumerator(IEnumerator enumerator, Action callback)
        {
            yield return enumerator;
            callback();
        }
    }
}
