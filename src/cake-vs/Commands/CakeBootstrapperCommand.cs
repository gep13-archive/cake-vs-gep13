//------------------------------------------------------------------------------
// <copyright file="CakeBootstrapperCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace cake_vs.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CakeBootstrapperCommand
    {
        public const int ConfigurationCommandId = 0x0100;

        public const int PowerShellBootstrapperCommandId = 0x0105;

        public const int BashBootstrapperCommandId = 0x0110;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("902d97dd-af7d-4781-b733-96132ebeb202");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CakeBootstrapperCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private CakeBootstrapperCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var configurationMenuCommandId = new CommandID(CommandSet, ConfigurationCommandId);
                var configurationMenuItem = new MenuCommand(this.ConfigurationMenuItemCallback, configurationMenuCommandId);
                commandService.AddCommand(configurationMenuItem);

                var powershellBootstrapperMenuCommandId = new CommandID(CommandSet, PowerShellBootstrapperCommandId);
                var powershellBootstrapperMenuItem = new MenuCommand(this.PowerShellBootstrapperMenuItemCallback, powershellBootstrapperMenuCommandId);
                commandService.AddCommand(powershellBootstrapperMenuItem);

                var bashBootstrapperMenuCommandId = new CommandID(CommandSet, BashBootstrapperCommandId);
                var bashBootstrapperMenuItem = new MenuCommand(this.BashBootstrapperMenuItemCallback, bashBootstrapperMenuCommandId);
                commandService.AddCommand(bashBootstrapperMenuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CakeBootstrapperCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new CakeBootstrapperCommand(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void ConfigurationMenuItemCallback(object sender, EventArgs e)
        {
            var message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.ConfigurationMenuItemCallback()", this.GetType().FullName);
            var title = "CakeBootstrapperCommand";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        private void PowerShellBootstrapperMenuItemCallback(object sender, EventArgs e)
        {
            var message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.PowerShellBootstrapperMenuItemCallback()", this.GetType().FullName);
            var title = "CakeBootstrapperCommand";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        private void BashBootstrapperMenuItemCallback(object sender, EventArgs e)
        {
            var message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.BashBootstrapperMenuItemCallback()", this.GetType().FullName);
            var title = "CakeBootstrapperCommand";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
