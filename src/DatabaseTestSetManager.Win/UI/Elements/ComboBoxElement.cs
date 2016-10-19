namespace DatabaseTestSetManager.Win.UI.Elements
{
    public class ComboBoxElement
    {
        public ComboBoxElement(object value, object display)
        {
            this.Value = value;
            this.Display = display;
        }

        public object Value { get; private set; }

        public object Display { get; private set; }
    }
}
