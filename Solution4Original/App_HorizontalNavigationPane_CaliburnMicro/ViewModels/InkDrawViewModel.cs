﻿using System.Linq;

using App_HorizontalNavigationPane_CaliburnMicro.Helpers;
using App_HorizontalNavigationPane_CaliburnMicro.Services.Ink;
using App_HorizontalNavigationPane_CaliburnMicro.Services.Ink.UndoRedo;

using Caliburn.Micro;

namespace App_HorizontalNavigationPane_CaliburnMicro.ViewModels
{
    public class InkDrawViewModel : Screen
    {
        private InkStrokesService _strokeService;
        private InkLassoSelectionService _lassoSelectionService;
        private InkPointerDeviceService _pointerDeviceService;
        private InkCopyPasteService _copyPasteService;
        private InkUndoRedoService _undoRedoService;
        private InkFileService _fileService;
        private InkZoomService _zoomService;

        private bool enableTouch = true;
        private bool enableMouse = true;
        private bool enableLassoSelection;

        public InkDrawViewModel()
        {
        }

        public void Initialize(
            InkStrokesService strokeService,
            InkLassoSelectionService lassoSelectionService,
            InkPointerDeviceService pointerDeviceService,
            InkCopyPasteService copyPasteService,
            InkUndoRedoService undoRedoService,
            InkFileService fileService,
            InkZoomService zoomService)
        {
            _strokeService = strokeService;
            _lassoSelectionService = lassoSelectionService;
            _pointerDeviceService = pointerDeviceService;
            _copyPasteService = copyPasteService;
            _undoRedoService = undoRedoService;
            _fileService = fileService;
            _zoomService = zoomService;

            _strokeService.CopyStrokesEvent += (s, e) => RefreshActions();
            _strokeService.SelectStrokesEvent += (s, e) => RefreshActions();
            _strokeService.ClearStrokesEvent += (s, e) => RefreshActions();
            _undoRedoService.UndoEvent += (s, e) => RefreshActions();
            _undoRedoService.RedoEvent += (s, e) => RefreshActions();
            _undoRedoService.AddUndoOperationEvent += (s, e) => RefreshActions();
            _pointerDeviceService.DetectPenEvent += (s, e) => EnableTouch = false;
        }

        public bool EnableTouch
        {
            get => enableTouch;
            set
            {
                Set(ref enableTouch, value);
                _pointerDeviceService.EnableTouch = value;
            }
        }

        public bool EnableMouse
        {
            get => enableMouse;
            set
            {
                Set(ref enableMouse, value);
                _pointerDeviceService.EnableMouse = value;
            }
        }

        public bool EnableLassoSelection
        {
            get => enableLassoSelection;
            set
            {
                Set(ref enableLassoSelection, value);
                ConfigLassoSelection(value);
            }
        }

        public void ZoomIn() => _zoomService?.ZoomIn();

        public void ZoomOut() => _zoomService?.ZoomOut();

        public void Cut()
        {
            _copyPasteService?.Cut();
            ClearSelection();
        }

        public void Copy()
        {
            _copyPasteService?.Copy();
        }

        public void Paste()
        {
            _copyPasteService?.Paste();
            ClearSelection();
        }

        public void Undo()
        {
            ClearSelection();
            _undoRedoService?.Undo();
        }

        public void Redo()
        {
            ClearSelection();
            _undoRedoService?.Redo();
        }

        public async void LoadInkFile()
        {
            ClearSelection();
            var fileLoaded = await _fileService?.LoadInkAsync();

            if (fileLoaded)
            {
                _undoRedoService?.Reset();
            }
        }

        public async void SaveInkFile()
        {
            ClearSelection();
            await _fileService?.SaveInkAsync();
        }

        public async void ExportAsImage()
        {
            ClearSelection();
            await _fileService?.ExportToImageAsync();
        }

        public void ClearAll()
        {
            var strokes = _strokeService?.GetStrokes().ToList();
            ClearSelection();
            _strokeService?.ClearStrokes();
            _undoRedoService?.AddOperation(new RemoveStrokeUndoRedoOperation(strokes, _strokeService));
        }

        private bool CanCut => _copyPasteService != null && _copyPasteService.CanCut;

        private bool CanCopy => _copyPasteService != null && _copyPasteService.CanCopy;

        private bool CanPaste => _copyPasteService != null && _copyPasteService.CanPaste;

        private bool CanUndo => _undoRedoService != null && _undoRedoService.CanUndo;

        private bool CanRedo => _undoRedoService != null && _undoRedoService.CanRedo;

        private bool CanSaveInkFile => _strokeService != null && _strokeService.GetStrokes().Any();

        private bool CanExportAsImage => _strokeService != null && _strokeService.GetStrokes().Any();

        private bool CanClearAll => _strokeService != null && _strokeService.GetStrokes().Any();

        private void RefreshActions()
        {
            NotifyOfPropertyChange(nameof(CanCut));
            NotifyOfPropertyChange(nameof(CanCopy));
            NotifyOfPropertyChange(nameof(CanPaste));
            NotifyOfPropertyChange(nameof(CanUndo));
            NotifyOfPropertyChange(nameof(CanRedo));
            NotifyOfPropertyChange(nameof(CanSaveInkFile));
            NotifyOfPropertyChange(nameof(CanExportAsImage));
            NotifyOfPropertyChange(nameof(CanClearAll));
        }

        private void ConfigLassoSelection(bool enableLasso)
        {
            if (enableLasso)
            {
                _lassoSelectionService?.StartLassoSelectionConfig();
            }
            else
            {
                _lassoSelectionService?.EndLassoSelectionConfig();
            }
        }

        private void ClearSelection() => _lassoSelectionService?.ClearSelection();
    }
}
