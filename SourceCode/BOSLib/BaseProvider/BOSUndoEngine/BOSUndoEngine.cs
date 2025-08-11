using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;


namespace BOSLib
{
    public abstract class BOSUndoEngine
    {
        protected Stack undoStack;
        protected Stack redoStack;
        protected BOSScreen _screen;

        public BOSUndoEngine(BOSScreen scr)
        {
            undoStack = new Stack();
            redoStack = new Stack();
            _screen = scr;
        }

        public BOSScreen Screen
        {
            get { return _screen; }
            set
            {
                _screen = value;
            }
        }       

        public void AddUndoUnit(BOSUndoUnit undoUnit)
        {
            undoStack.Push(undoUnit);
        }

        public BOSUndoUnit CreateUndoUnit(String strUndoUnitName,String strUndoUnitPropertyName, String strUndoUnitStatus, object objUndoUnitObject)
        {
            return new BOSUndoUnit(strUndoUnitName,strUndoUnitPropertyName, strUndoUnitStatus, objUndoUnitObject);
        }

        public void AddUndoUnit(String strUndoUnitName,String strUndoUnitPropertyName, String strUndoUnitStatus, object objUndoUnitObject)
        {
            BOSUndoUnit undoUnit = CreateUndoUnit(strUndoUnitName,strUndoUnitPropertyName, strUndoUnitStatus, objUndoUnitObject);
            undoStack.Push(undoUnit);
        }

        public abstract void Undo();

        public abstract void Redo();

        protected abstract void SetControlValue(BOSUndoUnit undoUnit);
       

        

    }

    
}
