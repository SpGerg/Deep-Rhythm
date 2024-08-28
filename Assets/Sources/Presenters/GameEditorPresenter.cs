using Models;
using Models.Interfaces;
using Presenters;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views;
using Views.Editor;
using Views.Interfaces;

namespace Presenters
{
    public class GameEditorPresenter : PresenterBase
    {
        public GameEditorPresenter(GameEditorView view) : base(view)
        {
            GameEditorView = view;
            GameEditorModel = new GameEditorModel(this);
        }

        protected GameEditorModel GameEditorModel { get; }

        protected GameEditorView GameEditorView { get; }

        public void OnSelected(GameEditorSlotView gameEditorSlotView)
        {
            if (!gameEditorSlotView.Image.enabled)
            {
                GameEditorModel.SetEnemy(gameEditorSlotView.Image);
            }
            else
            {
                GameEditorModel.RemoveEnemy(gameEditorSlotView.Image);
            }
        }
    }
}
