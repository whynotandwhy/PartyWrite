using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AvatarDisplayController : MonoBehaviour
{
    [Header("Sprite Options")]
    [SerializeField] protected Sprite[] bodySprites;    
    [SerializeField] protected Sprite[] faceSprites;
    [SerializeField] protected Sprite[] hairSprites;
    [SerializeField] protected Sprite[] clothingSprites;

    [Header("Avatar Positions")]
    [SerializeField] protected Image bodyDisplay;
    [SerializeField] protected Image faceDisplay;
    [SerializeField] protected Image hairDisplay;
    [SerializeField] protected Image clothingDisplay;
    [SerializeField] protected Image playerFaceDisplay;

    [Header("Editor Options")]
    [SerializeField] protected float fadeSpeed;
    [SerializeField] protected Sprite playerSad;
    [SerializeField] protected Sprite playerHappy;
    [SerializeField] protected Sprite playerNeutral;
    [SerializeField] protected Sprite playerSmug;

    protected bool fadeIn = false;

    public bool FadeIn { get => fadeIn; set => fadeIn = value; }

    public void PlayerHappy() => playerFaceDisplay.sprite = playerHappy;
    public void PlayerSad() => playerFaceDisplay.sprite = playerSad;
    public void PlayerNeutral() => playerFaceDisplay.sprite = playerNeutral;
    public void PlayerSmug() => playerFaceDisplay.sprite = playerSmug;

    [ContextMenu("Generate Customer Appearance")]
    public void GenerateRandomCustomer()
    {
        bodyDisplay.sprite = bodySprites[GetRandomRange(bodySprites.Length)];
        faceDisplay.sprite = faceSprites[GetRandomRange(faceSprites.Length)];
        hairDisplay.sprite = hairSprites[GetRandomRange(hairSprites.Length)];
        clothingDisplay.sprite = clothingSprites[GetRandomRange(clothingSprites.Length)];

        fadeIn = true;
    }

    protected int GetRandomRange(int arrayLength) => Random.Range(0, arrayLength - 1);

    protected void Update()
    {
        FadeCustomer();
    }

    protected void FadeCustomer()
    {
        if(fadeIn)
        {
            Color targetBodyAlpha = new Color(bodyDisplay.color.r, bodyDisplay.color.g, bodyDisplay.color.r, bodyDisplay.color.a);
            targetBodyAlpha.a = Mathf.Clamp01(bodyDisplay.color.a + (fadeSpeed * Time.deltaTime));

            Color targetFaceAlpha = new Color(faceDisplay.color.r, faceDisplay.color.g, faceDisplay.color.r, faceDisplay.color.a);
            targetFaceAlpha.a = Mathf.Clamp01(faceDisplay.color.a + (fadeSpeed * Time.deltaTime));

            Color targetHairAlpha = new Color(hairDisplay.color.r, hairDisplay.color.g, hairDisplay.color.r, hairDisplay.color.a);
            targetHairAlpha.a = Mathf.Clamp01(hairDisplay.color.a + (fadeSpeed * Time.deltaTime));

            Color targetClothesAlpha = new Color(clothingDisplay.color.r, clothingDisplay.color.g, clothingDisplay.color.r, clothingDisplay.color.a);
            targetClothesAlpha.a = Mathf.Clamp01(clothingDisplay.color.a + (fadeSpeed * Time.deltaTime));

            bodyDisplay.color = targetBodyAlpha;
            faceDisplay.color = targetFaceAlpha;
            hairDisplay.color = targetHairAlpha;
            clothingDisplay.color = targetClothesAlpha;
        }
        else
        {
            Color targetBodyAlpha = new Color(bodyDisplay.color.r, bodyDisplay.color.g, bodyDisplay.color.r, bodyDisplay.color.a);
            targetBodyAlpha.a = Mathf.Clamp01(bodyDisplay.color.a - (fadeSpeed * Time.deltaTime));

            Color targetFaceAlpha = new Color(faceDisplay.color.r, faceDisplay.color.g, faceDisplay.color.r, faceDisplay.color.a);
            targetFaceAlpha.a = Mathf.Clamp01(faceDisplay.color.a - (fadeSpeed * Time.deltaTime));

            Color targetHairAlpha = new Color(hairDisplay.color.r, hairDisplay.color.g, hairDisplay.color.r, hairDisplay.color.a);
            targetHairAlpha.a = Mathf.Clamp01(hairDisplay.color.a - (fadeSpeed * Time.deltaTime));

            Color targetClothesAlpha = new Color(clothingDisplay.color.r, clothingDisplay.color.g, clothingDisplay.color.r, clothingDisplay.color.a);
            targetClothesAlpha.a = Mathf.Clamp01(clothingDisplay.color.a - (fadeSpeed * Time.deltaTime));

            bodyDisplay.color = targetBodyAlpha;
            faceDisplay.color = targetFaceAlpha;
            hairDisplay.color = targetHairAlpha;
            clothingDisplay.color = targetClothesAlpha;
        }
    }    
}
