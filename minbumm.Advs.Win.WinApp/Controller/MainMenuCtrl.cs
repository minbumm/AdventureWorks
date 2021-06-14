using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minbumm.Advs.Win.WinApp.Controller
{
    public class MainMenuCtrl
    {
        static List<KeyValuePair<string, EventHandler>> menuEvents = new List<KeyValuePair<string, EventHandler>>();

        public MainMenuCtrl() 
        {
            
        }

        public static void AddMenuEventHandler(string key, EventHandler eventHandler) 
        {
            var handler = menuEvents.Where(e => e.Key == key).FirstOrDefault();
            if (handler.Key !=  null)
            {
                menuEvents.Remove(handler);
            }

            menuEvents.Add(new KeyValuePair<string, EventHandler>(key, eventHandler));
        }
        public static void RemoveMenuEventHandler(string key, EventHandler eventHandler) 
        {
            var handler = menuEvents.Where(m => m.Key == key).FirstOrDefault();

            if (handler.Key != null )
            {
                menuEvents.Remove(handler);
            }
        }
        public static void InvpkkeMenuEventHandler(string key, object sender, EventArgs e) 
        {
            var handler = menuEvents.Where(m => m.Key == key).FirstOrDefault();

            if (handler.Key != null && handler.Value != null)
            {
                handler.Value(sender, e);
            }
        }

        static private void menuItem_Click(object sender, EventArgs e) 
        {
            Debug.WriteLine(sender.ToString());
            Debug.WriteLine(e.ToString());

            ToolStripMenuItem tsItem = sender as ToolStripMenuItem;
            string key = tsItem.Tag as string;
            MainMenuCtrl.InvpkkeMenuEventHandler(key, sender, e);
        }

        private static Boolean PreventDuplicateShow(string targetFormName) 
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == targetFormName)
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return true;
                }
            }
            return false;
        }
    }
}
