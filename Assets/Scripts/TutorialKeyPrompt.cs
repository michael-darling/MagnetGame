using System.Linq;
using UnityEngine;

public class TutorialKeyPrompt : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] keyCodes;

    private void Update()
    {
        if (keyCodes.Any(key => Input.GetKeyDown(key)))
        {
            gameObject.SetActive(false);
        }
    }
}
