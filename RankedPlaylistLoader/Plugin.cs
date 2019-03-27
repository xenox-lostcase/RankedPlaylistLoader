using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using IllusionPlugin;

namespace RankedPlaylistLoader
{
    public class Plugin : IPlugin
    {
        public string Name => "Ranked Playlist Loader";
        public string Version => "0.0.1";

        private Downloader _downloader = null;

        private IEnumerator DelayedStartup()
        {
            yield return new WaitForSeconds(0.5f);
            _downloader = new GameObject().AddComponent<Downloader>();
        }

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            SharedCoroutineStarter.instance.StartCoroutine(DelayedStartup());
            
        }

        private void SceneManagerOnActiveSceneChanged(Scene oldScene, Scene newScene)
        {

            if (newScene.name == "Menu")
            {
                //Code to execute when entering The Menu

            }

            if (newScene.name == "GameCore")
            {
                //Code to execute when entering actual gameplay


            }


        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            //Create GameplayOptions/SettingsUI if using either
            if (scene.name == "Menu")
                UI.BasicUI.CreateUI();

        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {


        }

        public void OnFixedUpdate()
        {
        }

        public static void Log(string msg)
        {
            msg = $"[RankedPlaylistLoader] {msg}";
            Console.WriteLine(msg);
        }
    }
}
