using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public static class Language
    {
        static Dictionary<int, Dictionary<string, string>> _controlsText;
        static Dictionary<string, int> _formsIndex;

        public static string getControlText(string ControlName, string formName)
        {
            if (_controlsText[_formsIndex[formName]].ContainsKey(ControlName))
            {
                return _controlsText[_formsIndex[formName]][ControlName];
            }

            return "";
        }

        private static void initialization()
        {
            _controlsText = new Dictionary<int, Dictionary<string, string>>();
            _formsIndex = new Dictionary<string, int>();

            string fullFile = "";
            switch (CourseWork.Properties.Settings.Default.Language)
            {
                case "eng": fullFile = CourseWork.Properties.Resources.eng; break;
                case "rus": fullFile = CourseWork.Properties.Resources.ru; break;
            }
           
            foreach (string form in fullFile.Split('*')[0].Split('\r', '\n'))
            {
                if (form.Trim() != "")
                {
                    Dictionary<string, string> form_control = new Dictionary<string, string>();

                    int formID = Convert.ToInt32(form.Split('|')[1].Trim());
                    _formsIndex.Add(form.Split('|')[0].Trim(), formID);

                    foreach (string control in fullFile.Split('*')[formID].Split('\r', '\n'))
                    {
                        if (control.Trim() != "")
                        {
                            form_control.Add(control.Split('=')[0].Trim(), control.Split('=')[1].Trim());
                        }
                    }

                    _controlsText.Add(_formsIndex[form.Split('|')[0].Trim()], form_control);
                }
            }
        }

        public static void setControlsText(ref Control.ControlCollection Controls, string formName)
        {
            if (_controlsText == null && _formsIndex == null)
                { initialization(); }

            List<Control> allControls = takeAllControls(Controls);
            List<ToolStripMenuItem> menuItems = menuStripAnaliz(Controls);

            for (int i = 0; i < allControls.Count; i++)
            {
                Control tempControl = allControls[i];

                if (_controlsText[_formsIndex[formName]].ContainsKey(tempControl.Name))
                {
                    tempControl.Text = _controlsText[_formsIndex[formName]][tempControl.Name];
                }
            }

            for (int i = 0; i < menuItems.Count; i++)
            {
                var tempControl = menuItems[i];

                if (_controlsText[_formsIndex[formName]].ContainsKey(tempControl.Name))
                {
                    tempControl.Text = _controlsText[_formsIndex[formName]][tempControl.Name];
                }
            }
        }

        private static List<Control> takeAllControls(Control.ControlCollection controls)
        {
            List<Control> tempControlsList = new List<Control>();

            for (int i = 0; i < controls.Count; i++)
            {
                tempControlsList.Add(controls[i]);
                if (controls[i].Controls.Count > 0)
                {
                    tempControlsList.AddRange(takeAllControls(controls[i].Controls));
                }
            }

            return tempControlsList;
        }

        private static List<ToolStripMenuItem> menuStripAnaliz(Control.ControlCollection controls)
        {
            List<ToolStripMenuItem> tempMenuItems = new List<ToolStripMenuItem>();

            foreach (var control in controls)
            {
                if (control is MenuStrip)
                {
                    MenuStrip tempMS = control as MenuStrip;
                    foreach (ToolStripMenuItem item in tempMS.Items)
                    {
                        tempMenuItems.Add(item);
                        if (item.HasDropDownItems)
                        {
                            tempMenuItems.AddRange(takeAllMenuStripItems(item));
                        }
                    }
                }
            }

            return tempMenuItems;
        }

        private static List<ToolStripMenuItem> takeAllMenuStripItems(ToolStripMenuItem dropDownItems)
        {
            List<ToolStripMenuItem> tempMenuItems = new List<ToolStripMenuItem>();

            foreach (ToolStripMenuItem item in dropDownItems.DropDownItems)
            {
                tempMenuItems.Add(item);
                if (item.HasDropDownItems)
                {
                    tempMenuItems.AddRange(takeAllMenuStripItems(item));
                }
            }

            return tempMenuItems;
        }
    }
}
