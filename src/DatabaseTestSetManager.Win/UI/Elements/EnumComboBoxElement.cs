using System;

namespace DatabaseTestSetManager.Win.UI.Elements
{
    public class EnumComboBoxElement<T> where T : struct
    {
        public EnumComboBoxElement(T value)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            this.Value = value;

            // Get the description if possible
            this.Description = ((Enum)(object)value).GetDescription();
        }

        public T Value { get; private set; }

        public string Description { get; private set; }

        public override string ToString()
        {
            return this.Description;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
