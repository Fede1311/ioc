using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lupi.DependencyResolver;
using System.ComponentModel.Composition;


namespace Lupi.BusinessLogic
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IBreedBusinessLogic, BreedBusinessLogic>();
        }
    }
}
