using System;
using System.ComponentModel;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal class ConcreteUserControlProvider : TypeDescriptionProvider
    {
        public ConcreteUserControlProvider() : base(TypeDescriptor.GetProvider(typeof(AbstractUserControl))) { }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(AbstractUserControl))
            {
                return typeof(ConcreteUserControl);
            }
            return base.GetReflectionType(objectType, instance);
        }


        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(AbstractUserControl))
            {
                objectType = typeof(ConcreteUserControl);
            }

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
