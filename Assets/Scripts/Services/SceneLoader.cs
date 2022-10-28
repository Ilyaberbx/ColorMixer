using UnityEngine.SceneManagement;
using ColorMixer.Interfaces;
using UnityEngine;

namespace ColorMixer.Scene
{
    public class SceneLoader : ISceneLoader
    {

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void NextLevel()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if(CheckForIndexEdge(buildIndex))
                SceneManager.LoadScene(0);
          
            else
                SceneManager.LoadScene(buildIndex);
      
        }
        private bool CheckForIndexEdge(int buildIndex)
        {
            if (buildIndex > SceneManager.sceneCountInBuildSettings - 1)
                return true;

            return false;
        }

    }
}
