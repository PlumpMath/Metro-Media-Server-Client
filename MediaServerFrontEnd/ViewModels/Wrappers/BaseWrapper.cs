using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServerFrontEnd.ViewModels.Wrappers
{
    /// <summary>
    /// Allows us to keep models in another layer, independant of the viewmodel logic.
    /// </summary>
    /// <typeparam name="T">Type to Wrap</typeparam>
    public abstract class BaseWrapper<T> : PropertyChangedBase
    {
        public T Model { get; set; }

        public BaseWrapper(T Model)
        {
            this.Model = Model;
        }
    }
}
