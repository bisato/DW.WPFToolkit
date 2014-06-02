namespace DW.WPFToolkit.Controls
{
    public class MessageBoxStrings
    {
        private string _ok;
        private string _cancel;
        private string _abort;
        private string _retry;
        private string _ignore;
        private string _yes;
        private string _no;
        private string _help;
        private string _tryAgain;
        private string _continue;

        public string OK
        {
            get { return Load(SystemTexts.OK_CAPTION, _ok); }
            set { _ok = value; }
        }

        public string Cancel
        {
            get { return Load(SystemTexts.CANCEL_CAPTION, _cancel); }
            set { _cancel = value; }
        }

        public string Abort
        {
            get { return Load(SystemTexts.ABORT_CAPTION, _abort); }
            set { _abort = value; }
        }

        public string Retry
        {
            get { return Load(SystemTexts.RETRY_CAPTION, _retry); }
            set { _retry = value; }
        }

        public string Ignore
        {
            get { return Load(SystemTexts.IGNORE_CAPTION, _ignore); }
            set { _ignore = value; }
        }

        public string Yes
        {
            get { return Load(SystemTexts.YES_CAPTION, _yes); }
            set { _yes = value; }
        }

        public string No
        {
            get { return Load(SystemTexts.NO_CAPTION, _no); }
            set { _no = value; }
        }

        public string Help
        {
            get { return Load(SystemTexts.HELP_CAPTION, _help); }
            set { _help = value; }
        }

        public string TryAgain
        {
            get { return Load(SystemTexts.TRYAGAIN_CAPTION, _tryAgain); }
            set { _tryAgain = value; }
        }

        public string Continue
        {
            get { return Load(SystemTexts.CONTINUE_CAPTION, _continue); }
            set { _continue = value; }
        }

        private string Load(uint id, string alternate)
        {
            if (!string.IsNullOrWhiteSpace(alternate))
                return alternate;
            var systemString = SystemTexts.GetString(id);
            return systemString.Replace('&', '_');
        }
    }
}