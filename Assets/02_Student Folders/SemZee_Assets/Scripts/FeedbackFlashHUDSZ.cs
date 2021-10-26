using UnityEngine;
using UnityEngine.UI;

public class FeedbackFlashHUDSZ : MonoBehaviour
{
    PlayerCharacterController player;
    [Header("Dancing Heart Pickup")]
    public CanvasGroup heartCanvasGroup;
    public CanvasGroup PinkOverlayCanvasGroup;
    public float heartMaxAlpha = .8f;
    public float pulsatingHeartFrequency = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, FeedbackFlashHUD>(player, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.heartIsOn)
        {
            heartCanvasGroup.gameObject.SetActive(true);
            PinkOverlayCanvasGroup.gameObject.SetActive(true);
            PinkOverlayCanvasGroup.alpha = 0.3f;
            heartCanvasGroup.alpha = ((Mathf.Sin(Time.time * pulsatingHeartFrequency) / 2) + 0.5f) * heartMaxAlpha;
        }
        else
        {
            heartCanvasGroup.gameObject.SetActive(false);
            PinkOverlayCanvasGroup.gameObject.SetActive(false);
        }
    }
}
