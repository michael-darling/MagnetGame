using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TutorialKeyPrompt : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] keyCodes;

    [SerializeField]
    private UnityEvent keyPressed;

    private void Update()
    {
        if (keyCodes.Any(key => Input.GetKeyDown(key)))
        {
            gameObject.SetActive(false);
            keyPressed.Invoke();
        }
    }
}
