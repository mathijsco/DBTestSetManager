namespace DatabaseTestSetManager.Win.UI.Elements
{
    public class ComboBoxErrorElement : ComboBoxElement
    {
        public ComboBoxErrorElement(object value, object display, string errorMessage)
            : base(value, display)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
    }
}
