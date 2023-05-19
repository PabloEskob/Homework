namespace Game_v1.CodeBase.UI.Elements
{
    public sealed class PauseButton : GameButton
    {
        protected override void Use()
        {
            buttonService.Use();
        }
    }
}