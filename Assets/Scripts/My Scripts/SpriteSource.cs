using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSource", menuName = "Scriptable Objects/SpriteSource")]
public class SpriteSource : ScriptableObject
{
    [Header("가시")]
    public Sprite redThorn;
    public Sprite blueThorn;
    public Sprite greenThorn;

    [Header("눈알")]
    public Sprite defaultSprite;
    public Sprite angelSprite;
    public Sprite devilSprite;
}
