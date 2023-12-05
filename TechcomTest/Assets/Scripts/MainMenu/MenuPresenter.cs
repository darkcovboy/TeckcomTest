using System.Collections.Generic;

namespace MainMenu
{
    public class MenuPresenter
    {
        private List<ICloseble> _closebles;

        public MenuPresenter(List<ICloseble> closebles)
        {
            _closebles = closebles;
        }

        public void Open(Panels panel)
        {
            ICloseble panelToOpen = GetPanel(panel);
            panelToOpen?.OpenPanel();
        }
        
        private ICloseble GetPanel(Panels panel)
        {
            return _closebles.Find(p => p.GetPanelType() == panel);
        }
    }
}