using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Shared.Extensions;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Shared.Helpers;
using Sifon.Shared.Model;
using Sifon.Shared.Model.Fake;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Site;
using Sifon.Shared.Statics;

namespace Sifon.Forms
{
    public partial class Test : Form
    {
        private ScriptWrapper<SolrInfo> wrapper;
        //private readonly ScriptWrapper<DirectoryInfo> _scriptWrapper;

        public Test()
        {
            InitializeComponent();
            //_scriptWrapper = new ScriptWrapper<DirectoryInfo>(profile, this, pso => pso.Convert<DirectoryInfo>());
        }
        //private KeyValuePair<string, string> ConvertToList(PSObject arg)
        //{
        //    var infos = arg.ToStringArray();
        //    return new KeyValuePair<string, string>(infos[0], infos[1]);
        //}



        public IProfile profile = new Profile
        {
            RemotingEnabled = true,
            RemoteExecutionHost = "172.17.223.187",
            RemoteUsername = "Martin",
            RemotePassword = "321",
            RemoteFolder = @"c:\Users\Martin\Documents\Sifon\"
        };
        public IProfile LocalProfile = new Profile
        {
            RemotingEnabled = false,
            RemoteExecutionHost = "",
            RemoteUsername = "",
            RemotePassword = ""
        };

        private void run_Click(object sender, EventArgs e)
        {
            Toggle(false);

            //var _remoteScriptCopier = new RemoteScriptCopier(profile, this);
            //var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.GetFiles);

            //var parameters = new Dictionary<string, dynamic> { { "Type", "File" }, { "Directory", profile.RemoteFolder } };
            //var res = _scriptWrapper.RunSync(script, parameters);

            
            //var res = _scriptWrapper.Results;

            //await _getSites.Run(script);
            //var res = _getSites.Results;


            //string script = $@"ls -{parameter} {directoryPath} |  ForEach-Object {{ $_.FullName }}";

            //var _scriptWrapper = new ScriptWrapper<string>(profile, this, d => d.ToString());

            /*
                var type = "Directory";
                var directoryPath = @"c:\Users\Martin\Documents";
                var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.Filesystem.CopyToRemote);
                var parameters = new Dictionary<string, dynamic> {{"Type", type }, {"Directory", directoryPath}};
            */
            /*
                var _scriptWrapperBool = new ScriptWrapper<bool>(profile, this, d => true);
                var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.Filesystem.DeleteDirectory);
                var parameters = new Dictionary<string, dynamic> { { "Directory", @"c:\Users\Martin\Documents\Sifon\Test12300" } };
            */
            /*
                var _scriptWrapperBool = new ScriptWrapper<bool>(profile, this, d => true);
                var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.Filesystem.RenameDirectory);
                var parameters = new Dictionary<string, dynamic>
                {
                    { "OldPath", @"c:\Users\Martin\Documents\Sifon\Test00000" },
                    { "NewPath", @"c:\Users\Martin\Documents\Sifon\Test12345" }
                };
            */
            /*
                var _scriptWrapperBool = new ScriptWrapper<bool>(profile, this, d => bool.Parse(d.ToString()));
                var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.Filesystem.VerifyDirectory);
                var parameters = new Dictionary<string, dynamic> { { "Directory", @"c:\Users\Martin\Documents\Sifon\Test12345" } };
            */
            //var _scriptWrapperBool = new ScriptWrapper<Sifon.Shared.Model.Fake.DriveInfo>(profile, this, d => bool.Parse(d.ToString()));

            //await _scriptWrapperBool.Run(script, parameters);
            //var k = _scriptWrapperBool.Results.FirstOrDefault();


            //var identifier = new LocalSiteProvider();
            //var sites = await identifier.GetSitecoreSites();
            //var bindings = await identifier.GetBindings(sites.First().Key);


            //var remoteSiteProvider = new RemoteSiteProvider(profile, this);
            //var sites = await remoteSiteProvider.GetSitecoreSites();
            //var results = sites.Result;
            //await wrapper.Run(Settings.Scripts.RetrieveSolr);
            //var res = wrapper.Results; 

            //var _scriptWrapperBool = new ScriptWrapper<bool>(profile, this, d => bool.Parse(d.ToString()));

            //var script =  _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.VerifyDirectory);
            //await _scriptWrapperBool.Run(script, new Dictionary<string, dynamic> { { "Directory", @"c:\Backups\01\" } });

            //var res= _scriptWrapperBool.Results.First();

            Toggle(true);
        }



        //private SolrInfo Convert(PSObject data)
        //{
        //    var s = data.BaseObject as string[];
        //    string version = new RegexHelper("^@{solr-spec-version=(.*)}$").Extract(s[1]);
        //    return new SolrInfo { Url = $"https://localhost:{s[0]}/solr", Version = version, Directory = s[2] };

        //}

        private void cancel_Click(object sender, EventArgs e)
        {
            wrapper.Finish();
            Toggle(true);
        }

        private void Toggle(bool standby)
        {
            buttonRun.Enabled = standby;
            buttonCancel.Enabled = !standby;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //this.myTreeView.DataSource = new TreeViewFolderBrowserDataProvider();
            //// set drive types
            //this.myTreeView.DriveTypes
            //    = DriveTypes.LocalDisk | DriveTypes.NetworkDrive |
            //      DriveTypes.RemovableDisk |
            //      DriveTypes.CompactDisc;
            //// set checkbox behavior mode
            //this.myTreeView.CheckboxBehaviorMode = CheckboxBehaviorMode.SingleChecked;
            //// fill root level
            //this.myTreeView.Populate();

            var browser = new FolderBrowser(LocalProfile, true) { StartPosition = FormStartPosition.CenterParent, Text = "Browse" };
            var res = browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
        }
    }
}
