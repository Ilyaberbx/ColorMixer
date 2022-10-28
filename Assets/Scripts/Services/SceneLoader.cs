using UnityEngine.SceneManagement;
using ColorMixer.Interfaces;

namespace ColorMixer.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void NextLevel()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(buildIndex);
        }
    }
}
