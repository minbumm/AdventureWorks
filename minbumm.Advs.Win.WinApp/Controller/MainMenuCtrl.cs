using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var hander = menuEvents.Where(e => e.Key == key).FirstOrDefault();
            if (hander.Key !=  null)
            {
                menuEvents.Remove(hander);
            }

            menuEvents.Add(new KeyValuePair<string, EventHandler>(key, eventHandler));
        }
    }
}
