using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VersionAdjustment
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Properties

        private string AllPathConfigurationFileName
        {
            get { return "VersionAdjustment.config"; }
        }

        #endregion

        #region Private Methods

        private void WriteToConfigurationFile(ListBox.ObjectCollection inSelectedPaths)
        {
            var fileStream = File.Create(AllPathConfigurationFileName);
            var streamWriter = new StreamWriter(fileStream);

            foreach (var selectedPath in inSelectedPaths)
            {
                streamWriter.WriteLine(selectedPath);
            }

            streamWriter.Close();
            fileStream.Close();
        }

        private object[] ReadFromConfigurationFile()
        {
            object[] result = new object[0];

            if (File.Exists(AllPathConfigurationFileName))
            {
                var fileStream = File.OpenRead(AllPathConfigurationFileName);
                var streamReader = new StreamReader(fileStream);

                result = streamReader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(p => p.Trim() != string.Empty).Cast<object>().ToArray();

                fileStream.Close();
            }

            return result;
        }

        private IEnumerable<Tuple<string, string>> GetVersionFiles(string inPath)
        {
            IList<Tuple<string, string>> result = new List<Tuple<string, string>>();

            var queue = new Queue<string>();

            queue.Enqueue(inPath);

            Application.DoEvents();
            while (queue.Count != 0)
            {
                var currentPath = queue.Dequeue();

                var directories = Directory.GetDirectories(currentPath);

                if (!currentPath.Contains(".svn"))
                {
                    foreach (var directory in directories)
                    {
                        queue.Enqueue(directory);
                    }
                }

                if (directories.Count(p => p.ToLower().Trim() == (currentPath + "\\properties").ToLower().Trim()) == 1 &&
                    directories.Count(p => p.ToLower().Trim() == (currentPath + "\\AssemblyIdentification").ToLower().Trim()) == 1)
                {
                    result.Add(new Tuple<string, string>(currentPath + "\\properties\\AssemblyInfo.cs", currentPath + "\\AssemblyIdentification\\AssemblyIdentification.cs"));
                }
            }

            return result;
        }

        private string GetVersion(string inPropertiesFile)
        {
            string result = "";

            var propertiesLines = File.ReadAllLines(inPropertiesFile);

            foreach (var propertiesLine in propertiesLines)
            {
                if (propertiesLine.Contains("AssemblyVersion") && !propertiesLine.Contains("//"))
                {
                    var texts = propertiesLine.Split('"');

                    result = texts[1];

                    break;
                }
            }

            return result;
        }

        private string GetGuid(string inPropertiesFile)
        {
            string result = "";

            var propertiesLines = File.ReadAllLines(inPropertiesFile);

            foreach (var propertiesLine in propertiesLines)
            {
                if (propertiesLine.Contains("Guid") && !propertiesLine.Contains("//"))
                {
                    var texts = propertiesLine.Split('"');

                    result = texts[1];

                    break;
                }
            }

            return result;
        }

        private void SetParameters(string inAssemblyIdentifierFile, string inVersion, string inGuid)
        {
            var lines = File.ReadAllLines(inAssemblyIdentifierFile);

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains("return new Guid(\""))
                {
                    var texts = lines[index].Split('"');

                    texts[1] = inGuid;

                    lines[index] = texts[0] + "\"" + inGuid + "\"" + texts[2];

                    break;
                }
            }

            for (int index = 0; index < lines.Length; index++)
            {
                if (lines[index].Contains("return \""))
                {
                    var texts = lines[index].Split('"');

                    texts[1] = inGuid;

                    lines[index] = texts[0] + "\"" + inVersion + "\"" + texts[2];

                    break;
                }
            }

            File.WriteAllLines(inAssemblyIdentifierFile, lines);
        }

        private string Affect(string inPropertiesFile, string inAssemblyIdentifierFile)
        {
            var version = GetVersion(inPropertiesFile);
            var guid = GetGuid(inPropertiesFile);

            string result = inPropertiesFile + "(" + version + ")";

            SetParameters(inAssemblyIdentifierFile, version, guid);

            return result;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            listBoxAllPath.Items.AddRange(ReadFromConfigurationFile());
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectedPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSelectedPath.Text.Trim()))
            {
                if (!listBoxAllPath.Items.Contains(textBoxSelectedPath.Text.Trim()))
                {
                    listBoxAllPath.Items.Add(textBoxSelectedPath.Text.Trim());
                }
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            WriteToConfigurationFile(listBoxAllPath.Items);

            listBox.Items.Clear();
            toolStripStatusLabelCount.Text = 0.ToString(CultureInfo.InvariantCulture);

            buttonSet.Enabled = false;
            Refresh();

            if (listBoxAllPath.Items.Count != 0)
            {
                var files = GetVersionFiles(listBoxAllPath.Items[0].ToString());

                for (int index = 1; index < listBoxAllPath.Items.Count; index++)
                {
                    files.Union(GetVersionFiles(listBoxAllPath.Items[index].ToString()));
                }

                Application.DoEvents();
                foreach (var tuple in files)
                {
                    listBox.Items.Add(Affect(tuple.Item1, tuple.Item2).Substring(textBoxSelectedPath.Text.Length));
                    listBox.SetSelected(listBox.Items.Count - 1, true);
                }

                toolStripStatusLabelCount.Text = listBox.Items.Count.ToString(CultureInfo.InvariantCulture);
            }

            buttonSet.Enabled = true;
        }

        #endregion
    }
}
