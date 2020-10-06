using System.ComponentModel;
using System.Windows.Forms;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    [TypeDescriptionProvider(typeof(ConcreteUserControlProvider))]

    internal abstract class AbstractUserControl : UserControl
    {

        public ProfilesPresenter Presenter
        {
            get
            {
                var form = Parent?.Parent?.Parent as Form;
                if (form is Profiles profiles)
                {
                    return profiles.Presenter;
                }

                return null;
            }
        }


        public abstract void SetTooltips();

        public abstract void AddPassiveValidationHandlers();
    }
}
