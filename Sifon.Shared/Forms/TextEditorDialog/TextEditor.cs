using Sifon.Abstractions.Profiles;
using System.Windows.Forms;
using Sifon.Abstractions.Helpers;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Shared.Forms.Base;

namespace Sifon.Shared.Forms.TextEditorDialog
{
    public partial class TextEditor : BaseDialog
    {
        private string _filePath;
        private IProfile _profile;
        private IRequestHelper _requestHelper;

        public TextEditor()
        {
            InitializeComponent();
        }

        private async void TextEditor_Load(object sender, System.EventArgs e)
        {
            ToggleControls(false);

            buttonSave.Select();
            Text = Text += $" - {_filePath} - {_profile.WindowCaptionSuffix}";

            if (_filePath.IsRelativePath())
            {
                _requestHelper = Create.WithCurrentProfile<IRequestHelper>(this);
                textContent.Text = await _requestHelper.ReadUrlContent(_filePath);
            }
            else
            {
                var _filesystem = Create.Filesystem.WithSpecificProfile(_profile, this);
                textContent.Text = await _filesystem.ReadTextFile(_filePath);
            }

            ToggleControls(true);
        }

        public string Read(IProfile profile, string filePath)
        {
            _profile = profile;
            _filePath = filePath;

            StartPosition = FormStartPosition.CenterParent;
            if (ShowDialog() == DialogResult.OK)
            {
                return textContent.Text;
            }

            return null;
        }

        private void ToggleControls(bool enabled)
        {
            textContent.Enabled = enabled;
            buttonSave.Enabled = enabled;
        }

        /*
            Commented below: an ability for TextEditor to show content from URLs.

            ### $Content = new Sifon.Shared.Forms.TextEditorDialog.TextEditor::ReadConfig($Profile, "/sitecore/admin/showConfig.aspx")
            param($Content)        

            public string ReadConfig(IProfile profile, string relativePath)
            {
                _profile = profile;
                _filePath = relativePath;

                //TODO: Disable 'Save' button

                StartPosition = FormStartPosition.CenterParent;
                if (ShowDialog() == DialogResult.OK)
                {
                    return textContent.Text;
                }

                return null;
            }
            private bool IsUrl(string path)
            {
                Uri uriResult;
                return Uri.TryCreate(path, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            }
        */
    }
}
