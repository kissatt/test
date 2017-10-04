using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace OnlabModule
{
    public class OnlabModule : IModule
    {
        private readonly IRegionManager regionManager;

        public OnlabModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.TabView));
            regionManager.RegisterViewWithRegion("AddTeamTabRegion", typeof(Views.AddTeamView));
            regionManager.RegisterViewWithRegion("TimeMeasureRegion", typeof(Views.TimeMeasureView));
            regionManager.RegisterViewWithRegion("SummaryRegion", typeof(Views.SummaryView));
        }
    }
}
