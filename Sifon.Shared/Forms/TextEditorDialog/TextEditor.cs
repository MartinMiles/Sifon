using Sifon.Abstractions.Profiles;
using System.Windows.Forms;
using Sifon.Code.Factories;
using Sifon.Shared.Forms.Base;

namespace Sifon.Shared.Forms.TextEditorDialog
{
    public partial class TextEditor : BaseDialog
    {
        private string _filePath;
        private IProfile _profile;

        public TextEditor()
        {
            InitializeComponent();
        }

        private async void TextEditor_Load(object sender, System.EventArgs e)
        {
            ToggleControls(false);

            buttonSave.Select();
            Text = Text += $" - {_filePath} - {_profile.WindowCaptionSuffix}";

            var _filesystem = Create.Filesystem.WithSpecificProfile(_profile, this);
            textContent.Text = await _filesystem.ReadTextFile(_filePath);

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
    }
}
