﻿using Trowel.Common.Shell.Settings;
using Trowel.Common.Translations;
using Trowel.Shell.Registers;
using System;
using System.ComponentModel.Composition;
using System.Drawing;

namespace Trowel.Shell.Settings.Editors
{
    [Export(typeof(ISettingEditorFactory))]
    public class ShellEditorsFactory : ISettingEditorFactory
    {
        [Import] private Lazy<TranslationStringsCatalog> _catalog;

        public string OrderHint => "W";

        public bool Supports(SettingKey key)
        {
            if (key.EditorType == "LanguageSelectionEditor")
            {
                return true;
            }
            else if (key.EditorType == "Dropdown")
            {
                return true;
            }
            else if (key.Type == typeof(string))
            {
                return true;
            }
            else if (key.Type.IsEnum)
            {
                return true;
            }
            else if (key.Type == typeof(bool))
            {
                return true;
            }
            else if (key.Type == typeof(int) || key.Type == typeof(decimal))
            {
                return true;
            }
            else if (key.Type == typeof(Color))
            {
                return true;
            }
            else if (key.Type == typeof(HotkeyRegister.HotkeyBindings))
            {
                return true;
            }
            return false;
        }

        public ISettingEditor CreateEditorFor(SettingKey key)
        {
            if (key.EditorType == "LanguageSelectionEditor")
            {
                return new LanguageSelectionEditor(_catalog.Value);
            }
            else if (key.EditorType == "Dropdown")
            {
                return new DropdownEditor();
            }
            else if (key.Type == typeof(string))
            {
                return new TextEditor();
            }
            else if (key.Type.IsEnum)
            {
                return new EnumEditor(key.Type);
            }
            else if (key.Type == typeof(bool))
            {
                return new BooleanEditor();
            }
            else if (key.Type == typeof(int) || key.Type == typeof(decimal))
            {
                if (key.EditorType == "Slider") return new SliderEditor();
                else return new NumericEditor();
            }
            else if (key.Type == typeof(Color))
            {
                return new ColorEditor();
            }
            else if (key.Type == typeof(HotkeyRegister.HotkeyBindings))
            {
                return new HotkeysEditor();
            }

            return null;
        }
    }
}