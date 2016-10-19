using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Debugging
{
    public sealed class TraceToControl : TraceListener
    {
        private readonly SplitContainer _splitContainer;
        private readonly TextBox _control;

        public TraceToControl(SplitContainer splitContainer, TextBox control)
        {
            if (splitContainer == null) throw new ArgumentNullException("splitContainer");
            if (control == null) throw new ArgumentNullException("control");
            _splitContainer = splitContainer;
            _control = control;
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            switch (eventType)
            {
                case TraceEventType.Verbose:
                case TraceEventType.Information:
                    WriteLine(message);
                    break;
                default:
                    WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}: {1}", eventType.ToString().ToUpperInvariant(), message));
                    break;
            }
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            TraceEvent(eventCache, source, eventType, id, string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public override void Write(string message)
        {
            AppendText(string.Format(CultureInfo.InvariantCulture, "[{0:HH:mm:ss.fff}] {1}", DateTime.Now, message));
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }

        private void AppendText(string text)
        {
            _control.BeginInvoke(new Action(() =>
            {
                if (_splitContainer.Panel2Collapsed)
                    _splitContainer.Panel2Collapsed = false;

                _control.Text = _control.Text + text;
                _control.Select(_control.TextLength, 0);
                _control.ScrollToCaret();
            }));
        }
    }
}
