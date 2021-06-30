using ChatApp.Client.WinForms.Connection;
using ChatApp.Client.WinForms.GUI.Forms;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client.WinForms.IoC
{
    public class SimpleInjectorContainer
    {
        public static Container GetContainer()
        {
            var container = new Container();

            container.Register<ConnectionHub>(Lifestyle.Singleton);

            AutoRegisterWindowsForms(container);
            container.Verify();

            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(MainForm).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
