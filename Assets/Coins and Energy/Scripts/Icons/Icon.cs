using UnityEngine;

public class Icon
{
    private Sprite _spriteIcon;

    public Icon(Sprite sprite)
    {
        _spriteIcon = sprite;
    }

    public Sprite SpriteIcon => _spriteIcon;
}