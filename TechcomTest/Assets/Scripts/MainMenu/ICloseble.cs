using System;

namespace MainMenu
{
    public interface ICloseble
    {
        Panels GetPanelType();
        public void OpenPanel();
        public void ClosePanel();
    }
}