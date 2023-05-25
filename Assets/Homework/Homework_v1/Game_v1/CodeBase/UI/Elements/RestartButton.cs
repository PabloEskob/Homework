namespace Game_v1.CodeBase.UI.Elements
{
    public sealed class RestartButton : GameButton
    {
        protected override void Use()
        {
            ButtonService.Use();
        }
    }
}