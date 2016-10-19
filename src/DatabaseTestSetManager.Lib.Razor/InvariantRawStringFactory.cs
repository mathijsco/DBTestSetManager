using RazorEngine.Text;
using System;
using System.Globalization;

namespace DatabaseTestSetManager.Lib.Razor
{
    /// <summary>
	/// Represents a factory that creates <see cref="T:RazorEngine.Text.RawString" /> instances with invariant culture setting.
	/// </summary>
    public class InvariantRawStringFactory : IEncodedStringFactory
    {
        /// <summary>
		/// Creates a <see cref="T:RazorEngine.Text.IEncodedString" /> instance for the specified raw string.
		/// </summary>
		/// <param name="value">Thevalue.</param>
		/// <returns>An instance of <see cref="T:RazorEngine.Text.IEncodedString" />.</returns>
		public IEncodedString CreateEncodedString(string value)
        {
            return new RawString(value);
        }

        /// <summary>
        /// Creates a <see cref="T:RazorEngine.Text.IEncodedString" /> instance for the specified object instance.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An instance of <see cref="T:RazorEngine.Text.IEncodedString" />.</returns>
        public IEncodedString CreateEncodedString(object value)
        {
            if (value is DateTime)
                return new RawString(((DateTime)value).ToString("o"));
            else if (value is DateTimeOffset)
                return new RawString(((DateTimeOffset)value).ToString("o"));

            if (value != null)
                return new RawString(Convert.ToString(value, CultureInfo.InvariantCulture));

            return new RawString(string.Empty);
        }
    }
}
