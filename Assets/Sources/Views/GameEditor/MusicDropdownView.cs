﻿using Models.GameEditor.Enums;
using System;
using TMPro;
using UnityEngine;

namespace Views.GameEditor
{
    public class MusicDropdownView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        [SerializeField]
        private GameEditorView _gameEditorView;

        public void SetMusicOnValueChanged(int id)
        {
            _gameEditorView.GameEditorPresenter.SetMusic(Enum.Parse<MusicType>(_dropdown.options[id].text.Replace(" ", ""), true));
        }
    }
}
