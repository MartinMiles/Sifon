using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifon.Forms.Solr
{
    partial class InstallSolr
    {
        //#region Passive validation on text changed and character entered

        //protected override void AddPassiveValidationHandlers()
        //{
        //    textName.KeyPress += NameAndPrefixKeyPress;
        //    textInstance.KeyPress += NameAndPrefixKeyPress;
        //    textUsername.KeyPress += NameAndPrefixKeyPress;
        //    textPassword.KeyPress += NameAndPrefixKeyPress;

        //    textName.TextChanged += TextHasChanged;
        //    textInstance.TextChanged += TextHasChanged;
        //    textUsername.TextChanged += TextHasChanged;
        //    textPassword.TextChanged += TextHasChanged;
        //}



        //private void NameAndPrefixKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char character = e.KeyChar;
        //    if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), GetFilterPattern(((TextBox)sender).Name)))
        //    {
        //        e.Handled = true;   // Stop the character from being entered into the control since it is illegal.
        //    }
        //}

        //private string GetFilterPattern(string name)
        //{
        //    if (name == textName.Name)
        //    {
        //        return Pattern.Filter.SpecialCharacters.Except.DotsDashesSpaces;
        //    }
        //    if (name == textInstance.Name)
        //    {
        //        return Pattern.Filter.SpecialCharacters.Except.DotsDashesParenthesesBackslash;
        //    }
        //    if (name == textUsername.Name)
        //    {
        //        return Pattern.Filter.SpecialCharacters.Except.DotsDashes;
        //    }
        //    if (name == textPassword.Name)
        //    {
        //        return Pattern.Filter.Whitespaces;
        //    }

        //    throw new ArgumentOutOfRangeException($"Control is not supporthe for passive validation: {name}");
        //}


        //private void UpdateButtonsState()
        //{
        //    bool buttonsEnabled = textName.Text.Length > 0
        //                          && textInstance.Text.Length > 0
        //                          && textUsername.Text.Length > 0
        //                          && textPassword.Text.Length > 0;

        //    buttonTest.Enabled = buttonsEnabled;
        //    buttonSave.Enabled = buttonsEnabled;
        //}

        //private void TextHasChanged(object sender, EventArgs e)
        //{
        //    UpdateButtonsState();
        //}

        //#endregion

        //#region Validates on form submission (last resort when copypasting)

        //private List<string> _validationMessages;


        //private bool ValidateForm()
        //{
        //    _validationMessages = new List<string>();

        //    if (!textName.ValidateRegex(Pattern.SqlSettings.Name))
        //    {
        //        _validationMessages.Add(Validation.SqlSettings.Name);
        //    }
        //    if (!textInstance.ValidateRegex(Pattern.SqlSettings.Instance))
        //    {
        //        _validationMessages.Add(Validation.SqlSettings.Instance);
        //    }
        //    if (!textUsername.ValidateRegex(Pattern.SqlSettings.Username))
        //    {
        //        _validationMessages.Add(Validation.SqlSettings.Username);
        //    }
        //    if (!textPassword.ValidateRegex(Pattern.SqlSettings.Password))
        //    {
        //        _validationMessages.Add(Validation.SqlSettings.Password);
        //    }
        //    return ShowValidationError(_validationMessages);
        //}

        //#endregion
    }
}
