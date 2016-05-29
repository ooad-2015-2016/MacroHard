using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;
using ShEM.BazaPodataka.Static_variables;

namespace ShEM.ViewModel
{
    public class MyCollectionsViewModel
    {
        public List<Collection> collections
        {
            get; set;
        }
        private StaticVariablesClass statics = new StaticVariablesClass();

        public MyCollectionsViewModel()
        {
            collections = statics.collections;
        }

    }
}
