using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZXingSample
{
    class APTModel
    {
        private Dictionary<string, string> PickerItems = new Dictionary<string, string>();

        public List<KeyValuePair<string, string>> PickerItemList
        {
            get => PickerItems.ToList();
        }

        private KeyValuePair<string, string> _selectedItem;
        public KeyValuePair<string, string> SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
        public void AddItem(string text, string key)
        {
            if(!PickerItems.ContainsKey(key))
                PickerItems.Add(key, text);
        }
    }
}
