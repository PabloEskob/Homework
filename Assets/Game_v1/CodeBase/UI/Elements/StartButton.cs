namespace Game_v1.CodeBase.UI.Elements
{
    public sealed class StartButton : GameButton
    {
        protected override void Use()
        {
            buttonService.Use();
            gameObject.SetActive(false);
        }
    }
}